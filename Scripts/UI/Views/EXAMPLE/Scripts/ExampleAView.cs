namespace HoodedCrow.uCore.UI.EXAMPLE
{
    using UnityEngine;
    using UnityEngine.UI;

    public class ExampleAView: AView
    {
        [SerializeField] private Button _showBViewButton;
        [SerializeField] private Button _showAdditiveViewButton;

        public override void Initialize(IViewsController<IView> viewsController)
        {
            base.Initialize(viewsController);

            _showBViewButton.onClick.AddListener(OnShowBViewButton);
            _showAdditiveViewButton.onClick.AddListener(OnShowAdditiveViewButton);
        }


        private void OnShowBViewButton()
        {
            _viewsController.Show<ExampleBView>();
        }

        private void OnShowAdditiveViewButton()
        {
            _viewsController.Show<ExampleAdditiveView>();
        }
    }
}
