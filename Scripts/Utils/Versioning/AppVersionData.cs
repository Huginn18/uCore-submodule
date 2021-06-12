namespace HoodedCrow.uCore.Utils.Versioning
{
    using System;
    using System.Text;
    using UnityEngine;

    public class AppVersionData: ScriptableObject
    {
        [SerializeField] private string _major = "0";
        [SerializeField] private string _minor = "0";
        [SerializeField] string _date = DateTime.Today.ToString("ddMMyyyy");
        [SerializeField] private string _codeName = string.Empty;

        private void Reset()
        {
            _major = "0";
            _minor = "0";
            UpdateDate();
        }

        [ContextMenu("Update Date")]
        public void UpdateDate()
        {
            _date = DateTime.Now.ToString("ddMMyyyy");
        }

        public override string ToString()
        {
            if (_codeName == String.Empty)
            {
                return $"{_major}.{_minor}.{_date}";
            }

            return $"{_major}.{_minor}.{_date} - {_codeName}";
        }

        #if UNITY_EDITOR
        public static AppVersionData LoadAppVersionData()
        {
            string[] guids = UnityEditor.AssetDatabase.FindAssets("t:AppVersionData");
            if (guids.Length == 0)
            {
                Debug.Log("Couldn't find App Version Data. Creating one...");
                AppVersionData newData = CreateInstance<AppVersionData>();
                UnityEditor.AssetDatabase.CreateAsset(newData, "Assets/App Version Data.asset");
                UnityEditor.AssetDatabase.SaveAssets();
                return newData;
            }

            if (guids.Length >= 2)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Multiple App Version Data objects found. Please remove duplicates.");
                foreach (string guid in guids)
                {
                    stringBuilder.AppendLine($"DUPLICATE: {UnityEditor.AssetDatabase.GUIDToAssetPath(guid)}");
                }
                Debug.LogError(stringBuilder.ToString());
            }

            string path = UnityEditor.AssetDatabase.GUIDToAssetPath(guids[0]);
            return UnityEditor.AssetDatabase.LoadAssetAtPath<AppVersionData>(path);
        }
        #endif
    }
}
