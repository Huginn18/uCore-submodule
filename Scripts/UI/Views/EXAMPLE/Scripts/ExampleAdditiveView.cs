namespace HoodedCrow.uCore.UI.EXAMPLE
{
    using UnityEngine;

    public class ExampleAdditiveView: AAdditiveView
    {
        [SerializeField] private ViewsController _subViewsController;
        public void Close()
        {
            _viewsController.Hide(this);
        }

        protected override void OnShowView()
        {
            base.OnShowView();
            _subViewsController.ShowDefaultView();
        }
    }
}
