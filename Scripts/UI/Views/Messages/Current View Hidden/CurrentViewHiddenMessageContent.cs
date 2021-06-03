namespace HoodedCrow.uCore.UI
{
    using HoodedCrow.uCore.Core;

    public struct CurrentViewHiddenMessageContent: IMessageContent
    {
        public AView View;

        public CurrentViewHiddenMessageContent(AView view)
        {
            View = view;
        }
    }
}
