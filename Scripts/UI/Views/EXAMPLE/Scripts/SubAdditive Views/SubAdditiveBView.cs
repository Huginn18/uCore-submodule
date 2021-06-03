namespace HoodedCrow.uCore.UI.EXAMPLE
{
    using UnityEngine;
    using UnityEngine.UI;

    public class SubAdditiveBView: ASubview<ExampleAdditiveView>
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _aSubviewButton;

        public override void Initialize(IViewsController<IView> viewsController)
        {
            base.Initialize(viewsController);

            _closeButton.onClick.AddListener(OnCloseButton);
            _aSubviewButton.onClick.AddListener(OnASubviewButton);
        }


        private void OnCloseButton()
        {
            _parentView.Close();
        }

        private void OnASubviewButton()
        {
            _viewsController.Show<SubAdditiveAView>();
        }
    }
}
