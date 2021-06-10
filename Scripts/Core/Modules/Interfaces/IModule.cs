namespace HoodedCrow.uCore.Core
{
    public interface IModule
    {
        void Initialize(IModulesManager modulesManager);
        void Uninitialize();
    }
}
