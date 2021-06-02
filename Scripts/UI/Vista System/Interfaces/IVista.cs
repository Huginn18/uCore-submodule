namespace HoodedCrow.uCore.UI
{
    public interface IVista
    {
        void Initialize(IVistaController<IVista> vistaController);

        void Show();
        void Hide();
    }
}
