namespace HoodedCrow.uCore.UI
{
    using HoodedCrow.uCore.Core;

    public struct AdditiveViewShowingMessageContent: IMessageContent
    {
        public AView View;

        public AdditiveViewShowingMessageContent(AView view)
        {
            View = view;
        }
    }
}
