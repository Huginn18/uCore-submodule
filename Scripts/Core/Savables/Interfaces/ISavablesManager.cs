namespace HoodedCrow.uCore.Core
{
    public interface ISavablesManager
    {
        void RegisterSavable(ISavable savable);
        void UnregisterSavable(ISavable savable);
    }
}
