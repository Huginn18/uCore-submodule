namespace HoodedCrow.uCore.Core
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName = "uCore/Core/Savables Manager")]
    public class SavablesManager: ScriptableObject, ISavablesManager
    {
        private Dictionary<Type, ISavable> _savables = new Dictionary<Type, ISavable>();

        [SerializeField] private string _saveFileName;

        [Space(10)]
        private JSONSerializer _jsonSerializer = new JSONSerializer();
        [SerializeField] private TextFilesManager _saveFilesManager;

        [Header("Messages - Listens")]
        [SerializeField] private SaveDataMessage _saveDataMessage;
        [SerializeField] private LoadDataMessage _loadDataMessage;


        public void Initialize()
        {
            _saveDataMessage.AddListener(OnSaveDataMessage);
            _loadDataMessage.AddListener(OnLoadDataMessage);
        }


        public void RegisterSavable(ISavable savable)
        {
            Type savableType = savable.GetType();

            if (_savables.ContainsKey(savableType))
            {
                throw new SavableDuplicateException($"Cannot register savable: {savableType.Name} is already registered");
            }

            _savables[savableType] = savable;
        }

        public void UnregisterSavable(ISavable savable)
        {
            Type savableType = savable.GetType();

            if (!_savables.ContainsKey(savableType))
            {
                throw new UnknownSavableTypeException($"Cannot unregister savable: {savableType.Name} isnot registered");
            }

            _savables.Remove(savableType);
        }


        private void OnSaveDataMessage(SaveDataMessageContent content)
        {
            Dictionary<Type, string> serializedDataCollection = new Dictionary<Type, string>();

            foreach (Type savableType in _savables.Keys)
            {
                string data = _savables[savableType].Serialize();
                serializedDataCollection[savableType] = data;
            }

            string serializedData = _jsonSerializer.Serialize(serializedDataCollection);
            _saveFilesManager.Overwrite($"{_saveFileName}.sav", serializedData);
        }

        private void OnLoadDataMessage(LoadDataMessageContent content)
        {
            Dictionary<Type, string> serializedDataCollection;

            string serializedData = _saveFilesManager.Read($"{_saveFileName}.sav");
            serializedDataCollection = _jsonSerializer.Deserialize<Dictionary<Type, string>>(serializedData);

            foreach (Type savableType in serializedDataCollection.Keys)
            {
                _savables[savableType].Deserialize(serializedDataCollection[savableType]);
            }
        }
    }
}
