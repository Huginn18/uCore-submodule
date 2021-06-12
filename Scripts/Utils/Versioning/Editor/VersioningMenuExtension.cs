namespace HoodedCrow.uCore.Utils.Versioning.Editor
{
    using System.Text;
    using NUnit.Framework;
    using UnityEditor;
    using UnityEngine;

    public class VersioningMenuExtension
    {
        [MenuItem("Tools/uCore/App Version")]
        public static void FocusOnVersionData()
        {
            AppVersionData data = AppVersionData.LoadAppVersionData();
            Selection.activeObject = data;
        }
    }
}
