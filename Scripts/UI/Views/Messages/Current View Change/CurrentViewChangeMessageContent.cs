namespace HoodedCrow.uCore.UI
{
    using HoodedCrow.uCore.Core;

    public struct CurrentViewChangeMessageContent: IMessageContent
    {
        public IView PreviousView;
        public IView CurrentView;

        public CurrentViewChangeMessageContent(IView previousView, IView currentView)
        {
            PreviousView = previousView;
            CurrentView = currentView;
        }
    }
}
