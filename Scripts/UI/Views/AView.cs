namespace HoodedCrow.uCore.UI
{
    using UnityEngine;

    public abstract class AView: MonoBehaviour, IView
    {
        public void Initialize(IViewsController<IView> viewsController)
        {
            throw new System.NotImplementedException();
        }

        public void Show()
        {
            throw new System.NotImplementedException();
        }

        public void Hide()
        {
            throw new System.NotImplementedException();
        }
    }
}
