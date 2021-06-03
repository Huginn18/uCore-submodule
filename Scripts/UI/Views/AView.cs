namespace HoodedCrow.uCore.UI
{
    using UnityEngine;

    public abstract class AView: MonoBehaviour, IView
    {
        [SerializeField] private GameObject _contentContainer;
        protected IViewsController<IView> _viewsController;

        public virtual void Initialize(IViewsController<IView> viewsController)
        {
            _viewsController = viewsController;
            _contentContainer.SetActive(false);
        }

        public void Show()
        {
            OnShowView();
            _contentContainer.SetActive(true);
        }

        public void Hide()
        {
            OnHideView();
            _contentContainer.SetActive(false);
        }

        protected virtual void OnShowView()
        {

        }

        protected virtual void OnHideView()
        {

        }
    }
}
