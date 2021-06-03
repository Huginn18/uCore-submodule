namespace HoodedCrow.uCore.UI
{
    using HoodedCrow.uCore.Core;

    public struct CurrentViewHiddenMessageContent: IMessageContent
    {
        public IView View;

        public CurrentViewHiddenMessageContent(IView view)
        {
            View = view;
        }
    }
}
