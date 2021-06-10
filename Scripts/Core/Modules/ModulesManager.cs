namespace HoodedCrow.uCore.Core
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class ModulesManager : MonoBehaviour, IModulesManager
    {
        [Header("Messages - Listens")]
        [SerializeField] private RegisterModuleMessage _registerModuleMessage;
        [SerializeField] private UnregisterModuleMessage _unregisterModuleMessage;

        private Dictionary<Type, IModule> _modules = new Dictionary<Type, IModule>();

        private void Awake()
        {
            _registerModuleMessage.AddListener(OnRegisterModuleMessage);
            _unregisterModuleMessage.AddListener(OnUnregisterModuleMessage);
        }

        private void OnDestroy()
        {
            _registerModuleMessage.Clear();
            _unregisterModuleMessage.Clear();
        }

        private void Update()
        {
            foreach (IModule module in _modules.Values)
            {
                if (module is IUpdatable updatable)
                {
                    updatable.Tick();
                }
            }
        }


        public TModule GetModule<TModule>() where TModule : IModule
        {
            Type moduleType = typeof(TModule);
            if (!_modules.ContainsKey(moduleType))
            {
                throw new UnknownModuleTypeException($"Cannot return module: {moduleType.Name} isnot registered");
            }

            return (TModule) _modules[moduleType];
        }


        private void OnRegisterModuleMessage(RegisterModuleMessageContent content)
        {
            Type moduleType = content.Module.GetType();
            if (_modules.ContainsKey(moduleType))
            {
                throw new ModuleDuplicateException($"Cannot register module: {moduleType.Name} is already registered");
            }

            _modules[moduleType] = content.Module;
            content.Module.Initialize(this);
        }

        private void OnUnregisterModuleMessage(UnregisterModuleMessageContent content)
        {
            Type moduleType = content.Module.GetType();
            if (!_modules.ContainsKey(moduleType))
            {
                throw new UnknownModuleTypeException($"Cannot unregister module: {moduleType.Name} wasn't registered");
            }

            IModule module = _modules[moduleType];
            _modules.Remove(moduleType);
            module.Uninitialize();
        }
    }
}
