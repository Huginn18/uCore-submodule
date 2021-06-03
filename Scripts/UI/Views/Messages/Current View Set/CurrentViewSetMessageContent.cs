namespace HoodedCrow.uCore.UI
{
    using HoodedCrow.uCore.Core;

    public struct CurrentViewSetMessageContent: IMessageContent
    {
        public AView View;

        public CurrentViewSetMessageContent(AView view)
        {
            View = view;
        }
    }
}
