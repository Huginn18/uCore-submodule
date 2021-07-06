namespace HoodedCrow.uCore.Core
{
    using System;

    public class Value<T>
    {
        private Action<T> _onValueChange;
        private T _value;

        public T GetValue()
        {
            return _value;
        }
        public void SetValue(T value)
        {
            _value = value;
        }

        public void UpdateValue(T value)
        {
            SetValue(value);
            _onValueChange.Invoke(_value);
        }

        public void AddListener(Action<T> callback)
        {
            _onValueChange += callback;
        }

        public void RemoveListener(Action<T> callback)
        {
            _onValueChange -= callback;
        }
    }
}
