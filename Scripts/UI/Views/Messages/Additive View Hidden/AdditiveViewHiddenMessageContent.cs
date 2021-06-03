namespace HoodedCrow.uCore.UI
{
    using HoodedCrow.uCore.Core;

    public struct AdditiveViewHiddenMessageContent: IMessageContent
    {
        public AView View;

        public AdditiveViewHiddenMessageContent(AView view)
        {
            View = view;
        }
    }
}
