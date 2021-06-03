namespace HoodedCrow.uCore.UI
{
    using HoodedCrow.uCore.Core;

    public struct CurrentViewChangeMessageContent: IMessageContent
    {
        public AView PreviousView;
        public AView CurrentView;

        public CurrentViewChangeMessageContent(AView previousView, AView currentView)
        {
            PreviousView = previousView;
            CurrentView = currentView;
        }
    }
}
