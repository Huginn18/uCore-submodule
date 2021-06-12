namespace HoodedCrow.uCore.Utils.Versioning.Editor
{
    using UnityEditor;

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
