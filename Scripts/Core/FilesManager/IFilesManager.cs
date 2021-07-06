namespace HoodedCrow.uCore.Core
{
    public interface IFilesManager<T>
    {
        void Create(string fileName);
        void Delete(string fileName);

        void Write(string fileName, T content);
        void Overwrite(string fileName, T content);

        T Read(string fileName);
    }
}
