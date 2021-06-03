namespace HoodedCrow.uCore.UI
{
    using HoodedCrow.uCore.Core;

    public struct CurrentViewSetMessageContent: IMessageContent
    {
        public IView View;

        public CurrentViewSetMessageContent(IView view)
        {
            View = view;
        }
    }
}
