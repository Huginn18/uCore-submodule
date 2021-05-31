namespace HoodedCrow.uCore.Core
{
    using UnityEngine;

    public abstract class ASOValue<T>: ScriptableObject
    {
        [SerializeField] private T _value;

        public T GetValue()
        {
            return _value;
        }
    }
}
