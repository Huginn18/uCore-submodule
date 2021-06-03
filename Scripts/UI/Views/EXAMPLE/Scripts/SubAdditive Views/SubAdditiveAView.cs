namespace HoodedCrow.uCore.UI.EXAMPLE
{
    using UnityEngine;
    using UnityEngine.UI;

    public class SubAdditiveAView: ASubview<ExampleAdditiveView>
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _bSubviewButton;


        public override void Initialize(IViewsController<IView> viewsController)
        {
            base.Initialize(viewsController);

            _closeButton.onClick.AddListener(OnCloseButton);
            _bSubviewButton.onClick.AddListener(OnBSubviewButton);
        }


        private void OnCloseButton()
        {
            _parentView.Close();
        }

        private void OnBSubviewButton()
        {
            _viewsController.Show<SubAdditiveBView>();
        }
    }
}
