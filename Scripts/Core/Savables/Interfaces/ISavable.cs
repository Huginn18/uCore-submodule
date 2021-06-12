namespace HoodedCrow.uCore.Core
{
    public interface ISavable
    {
        string Serialize();
        void Deserialize(string data);
    }
}
