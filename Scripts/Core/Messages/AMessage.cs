namespace HoodedCrow.uCore.Core
{
    using System;
    using UnityEngine;

    public abstract class AMessage<TContent>: ScriptableObject, IMessage<TContent> where TContent: IMessageContent
    {
        private Action<TContent> _callback;

        public void AddListener(Action<TContent> callback)
        {
            _callback += callback;
        }

        public void RemoveListener(Action<TContent> callback)
        {
            _callback -= callback;
        }

        public void Clear()
        {
            _callback = null;
        }

        public void Send(TContent content)
        {
            if (_callback == null)
            {
                Debug.LogWarning($"{GetType().Name} was sent but no one is listening to it.");
                return;
            }

            _callback.Invoke(content);
        }
    }
}
