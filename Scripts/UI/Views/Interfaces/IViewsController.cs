namespace HoodedCrow.uCore.UI
{
    public interface IViewsController<TVista> where TVista : IView
    {
        public TVista CurrentView { get; }

        public void Show<TVista>();
        public void Show(TVista vista);

        public void HideCurrentVista();
        public void Hide<TVista>();
        public void Hide(TVista vista);

        public void HideAllAdditiveVista();
    }
}
