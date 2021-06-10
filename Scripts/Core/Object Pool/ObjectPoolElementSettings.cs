namespace HoodedCrow.uCore.Core
{
    using System;
    using UnityEngine;

    [Serializable]
    public class ObjectPoolElementSettings
    {
        public string Naming => _naming;
        public GameObject Prefab => _prefab;
        public Transform Parent => _parent;
        public int MaxCapacity => _maxCapacity;

        [SerializeField] private string _naming = string.Empty;
        [SerializeField] private GameObject _prefab = null;
        [SerializeField] private Transform _parent = null;
        [SerializeField] private int _maxCapacity = 10;
    }
}
