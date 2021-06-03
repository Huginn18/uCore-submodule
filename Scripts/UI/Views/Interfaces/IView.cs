namespace HoodedCrow.uCore.UI
{
    public interface IView
    {
        void Initialize(IViewsController<IView> viewsController);

        void Show();
        void Hide();
    }
}
