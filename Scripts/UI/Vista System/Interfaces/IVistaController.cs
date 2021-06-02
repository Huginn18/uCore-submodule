namespace HoodedCrow.uCore.UI
{
    public interface IVistaController<TVista> where TVista : IVista
    {
        public TVista CurrentVista { get; }

        public void Show<TVista>();
        public void Show(TVista vista);

        public void HideCurrentVista();
        public void Hide<TVista>();
        public void Hide(TVista vista);

        public void HideAllAdditiveVista();
    }
}
