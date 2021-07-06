namespace HoodedCrow.uCore.Core
{
    using System.IO;
    using UnityEngine;

    [CreateAssetMenu(menuName = "uCore/Core/Text Files Manager")]
    public class TextFilesManager: ScriptableObject, IFilesManager<string>
    {
        [SerializeField] private FilesManagerType _managerType;
        [SerializeField] private string _path = string.Empty;


        private void OnValidate()
        {
            string path = GetDirectoryPath();

            if (_path != string.Empty && !Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }


        public void Create(string fileName)
        {
            FileStream fileStream = File.Create(GetPath(fileName));
            fileStream.Close();
        }

        public void Delete(string fileName)
        {
            File.Delete(GetPath(fileName));
        }

        public void Write(string fileName, string content)
        {
            StreamWriter streamWriter = File.AppendText(GetPath(fileName));
            streamWriter.WriteLine(content);
            streamWriter.Close();
        }

        public void Overwrite(string fileName, string content)
        {
            File.WriteAllText(GetPath(fileName), content);
        }

        public string Read(string fileName)
        {
            return File.ReadAllText(GetPath(fileName));
        }

        public string[] ReadLines(string fileName)
        {
            return File.ReadAllLines(GetPath(fileName));
        }

        protected virtual string GetPath(string fileName)
        {
            string path = GetDirectoryPath();

            path = Path.Combine(path, fileName);
            return path;
        }

        private string GetDirectoryPath()
        {
            string path = string.Empty;
            switch (_managerType)
            {
                case FilesManagerType.ApplicationData:
                    path = Application.dataPath;
                    break;
                case FilesManagerType.PersistentData:
                    path = Application.persistentDataPath;
                    break;
                case FilesManagerType.StreamingData:
                    path = Application.streamingAssetsPath;
                    break;
            }

            if (_path != string.Empty)
            {
                path = Path.Combine(path, _path);
            }

            return path;
        }
    }
}
