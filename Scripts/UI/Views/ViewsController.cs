namespace HoodedCrow.uCore.UI
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using HoodedCrow.uCore.Core;
    using UnityEngine;

    public class ViewsController: MonoBehaviour, IViewsController<IView>
    {
        public IView CurrentView => _currentView.GetValue();


        private Value<IView> _currentView = new Value<IView>();

        [SerializeField] private AView _defaultView;
        [SerializeField] private List<AView> _views;

        private Dictionary<Type, AView> _viewsCollection = new Dictionary<Type, AView>();
        private Dictionary<Type, AView> _additiveViewsCollection = new Dictionary<Type, AView>();

        [Header("Messages - Sends")]
        [SerializeField] private CurrentViewSetMessage _currentViewSetMessage;
        [SerializeField] private CurrentViewChangeMessage _currentViewChangeMessage;
        [SerializeField] private CurrentViewHiddenMessage _currentViewHiddenMessage;

        [SerializeField] private AdditiveViewShowingMessage _additiveViewShowingMessage;
        [SerializeField] private AdditiveViewHiddenMessage _additiveViewHiddenMessage;


        private void Awake()
        {
            _currentView.AddListener(view => _currentViewSetMessage.Send(new CurrentViewSetMessageContent(view)));
            foreach (AView view in _views)
            {
                _viewsCollection[view.GetType()] = view;
                view.Initialize(this);
            }
        }

        private void Start()
        {
            ShowDefaultView();
        }


        public void ShowDefaultView()
        {
            Show(_defaultView);
        }

        public void Show<TView>()
        {
            ShowView(typeof(TView));
        }

        public void Show(IView view)
        {
            ShowView(view.GetType());
        }


        public void HideCurrentVista()
        {
            HideView(_currentView.GetValue().GetType());
        }

        public void Hide<TView>()
        {
            HideView(typeof(TView));
        }

        public void Hide(IView view)
        {
            HideView(view.GetType());
        }


        public void HideAllAdditiveVista()
        {
            foreach (AView view in _additiveViewsCollection.Values)
            {
                Hide(view);
            }
            _additiveViewsCollection.Clear();
        }

        private void ShowView(Type viewType)
        {
            if (!_viewsCollection.ContainsKey(viewType))
            {
                throw new UnknownViewException($"Cannot show view: Unknown type {viewType.Name}");
            }

            AView view = _viewsCollection[viewType];
            if (view is IAdditive)
            {
                HandleShowAdditiveView(view);
                return;
            }

            HandleShowView(view);
        }

        private void HandleShowView(AView view)
        {
            if (_currentView.GetType() == view.GetType())
            {
                Debug.LogWarning($"Cannot show view: View {view.GetType().Name} already active");
                return;
            }

            if (_currentView.GetValue() == null)
            {
                view.Show();
                _currentView.UpdateValue(view);
                _currentViewChangeMessage.Send(new CurrentViewChangeMessageContent(null, view));
                return;
            }

            HandleCurrentViewChange(view);
        }

        private void HandleCurrentViewChange(AView view)
        {
            IView previousView = _currentView.GetValue();
            previousView.Hide();
            _currentView.SetValue(null);
            _currentViewHiddenMessage.Send(new CurrentViewHiddenMessageContent(previousView));

            view.Show();
            _currentView.UpdateValue(view);
            _currentViewChangeMessage.Send(new CurrentViewChangeMessageContent(previousView, view));
        }

        private void HandleShowAdditiveView(AView view)
        {
            Type viewType = view.GetType();
            if (_additiveViewsCollection.ContainsKey(viewType))
            {
                throw new DuplicateNameException($"Cannot show additive view: {viewType.Name} is already active");
            }

            view.Show();
            _additiveViewsCollection[viewType] = view;
            _additiveViewShowingMessage.Send(new AdditiveViewShowingMessageContent(view));
        }

        private void HideView(Type viewType)
        {
            AView view = _viewsCollection[viewType];
            if (view is IAdditive)
            {
                HandleHideAdditiveView(viewType);
                return;
            }

            HandleHideView(viewType);
        }

        private void HandleHideAdditiveView(Type viewType)
        {
            if (!_additiveViewsCollection.ContainsKey(viewType))
            {
                throw new UnknownViewException($"Cannot hide additive view: {viewType.Name} is not part of the additive views collection");
            }

            AView view = _additiveViewsCollection[viewType];
            _additiveViewsCollection.Remove(viewType);
            view.Hide();
            _additiveViewHiddenMessage.Send(new AdditiveViewHiddenMessageContent(view));
        }

        private void HandleHideView(Type viewType)
        {
            AView view = _viewsCollection[viewType];
            if (_currentView.GetValue() == view)
            {
                throw new NotCurrentViewException($"Cannot hide view: {viewType.Name} is not set as current view");
            }

            CurrentView.Hide();
            _currentViewChangeMessage.Send(new CurrentViewChangeMessageContent(CurrentView, null));
            _currentView.UpdateValue(null);
        }
    }
}
