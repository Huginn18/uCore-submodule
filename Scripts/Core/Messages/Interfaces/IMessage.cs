namespace HoodedCrow.uCore.Core
{
    using System;

    public interface IMessage<TContent> where TContent: IMessageContent
    {
        void AddListener(Action<TContent> callback);
        void RemoveListener(Action<TContent> callback);
        void Clear();
        void Send(TContent content);
    }
}
