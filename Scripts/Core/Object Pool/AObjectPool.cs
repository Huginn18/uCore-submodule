namespace HoodedCrow.uCore.Core
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Pool;

    public abstract class AObjectPool<TPool>: MonoBehaviour where TPool: IObjectPool<GameObject>
    {
        [SerializeField] private List<ObjectPoolElementSettings> _elements;
        [SerializeField] private Transform _parent;

        private Dictionary<Type, ObjectPoolElementSettings> _settings = new Dictionary<Type, ObjectPoolElementSettings>();
        private Dictionary<Type, TPool> _pools = new Dictionary<Type, TPool>();

        private void Awake()
        {
            foreach (ObjectPoolElementSettings settings in _elements)
            {
                Type type = settings.Prefab.GetType();

                _settings[type] = settings;
                _pools[type] = InstantiatePool(settings);
            }
        }

        public GameObject Get<T>() where T : MonoBehaviour
        {
            if (!_settings.ContainsKey(typeof(T)))
            {
                throw new UnknownPoolElementTypeException($"Cannot get pool element: Unknown type {typeof(T).Name}");
            }

            return _pools[typeof(T)].Get();
        }

        protected abstract TPool InstantiatePool(ObjectPoolElementSettings settings);

        protected virtual GameObject OnCreatePooledItem(Type type)
        {
            return Instantiate(_settings[type].Prefab);
        }

        protected virtual void OnTakeFromPool(GameObject gameObject, Type type)
        {
            string name = _settings[type].Naming;
            gameObject.name = name;
            gameObject.SetActive(true);
        }

        protected virtual void OnReturnedToPool(GameObject gameObject)
        {
            gameObject.SetActive(false);
            gameObject.transform.SetParent(_parent);
        }

        protected virtual void OnDestroyPoolObject(GameObject gameObject)
        {
            Destroy(gameObject);
        }
    }
}
