namespace HoodedCrow.uCore.UI.EXAMPLE
{
    using UnityEngine;
    using UnityEngine.UI;

    public class ExampleBView: AView
    {
        [SerializeField] private Button _showSubViewAButton;
        [SerializeField] private Button _backButton;

        public override void Initialize(IViewsController<IView> viewsController)
        {
            base.Initialize(viewsController);

            _showSubViewAButton.onClick.AddListener(OnShowSubViewAButton);
            _backButton.onClick.AddListener(OnBackButton);
        }

        private void OnShowSubViewAButton()
        {
            _viewsController.Show<ExampleAdditiveView>();
        }

        private void OnBackButton()
        {
            _viewsController.Show<ExampleAView>();
        }
    }
}
