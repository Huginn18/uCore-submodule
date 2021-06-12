namespace HoodedCrow.uCore.Utils.Versioning.Editor
{
    using System.Text;
    using UnityEditor;
    using UnityEditor.Build;
    using UnityEditor.Build.Reporting;
    using UnityEngine;

    public class AppVersionBuildPreprocessor: IPreprocessBuildWithReport
    {
        public int callbackOrder => 0;
        public void OnPreprocessBuild(BuildReport report)
        {
            string[] guids = AssetDatabase.FindAssets("t:AppVersionData");
            if (guids.Length == 0)
            {
                Debug.LogError("Couldn't find App Version Data. Please create one.");
                return;
            }

            if (guids.Length >= 2)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Multiple App Version Data objects found. Please remove duplicates.");
                foreach (string guid in guids)
                {
                    stringBuilder.AppendLine($"DUPLICATE: {AssetDatabase.GUIDToAssetPath(guid)}");
                }
                Debug.LogError(stringBuilder.ToString());
            }

            string path = AssetDatabase.GUIDToAssetPath(guids[0]);
            AppVersionData data = AssetDatabase.LoadAssetAtPath<AppVersionData>(path);
            data.UpdateDate();
        }
    }
}
