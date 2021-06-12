namespace HoodedCrow.uCore.Utils.Versioning
{
    using System;
    using TMPro;
    using UnityEditor;
    using UnityEngine;

    [RequireComponent(typeof(TextMeshProUGUI)), DisallowMultipleComponent]
    public class AppVersionDisplayer: MonoBehaviour
    {
        [SerializeField] private TMP_Text _versionLabel;
        [SerializeField] private AppVersionData _appVersionData;

        #if UNITY_EDITOR
        private void Reset()
        {
            _versionLabel = GetComponent<TMP_Text>();
            _appVersionData = AppVersionData.LoadAppVersionData();

            _versionLabel.text = $"v{_appVersionData}";
        }
        #endif

        private void Start()
        {
            _versionLabel.text = _appVersionData.ToString();
        }
    }
}
