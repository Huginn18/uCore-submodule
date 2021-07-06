namespace HoodedCrow.uCore.Core
{
    using UnityEngine;
    using UnityEngine.Pool;

    public interface IPoolElement
    {
        void SetPool(IObjectPool<GameObject> pool);
    }
}
