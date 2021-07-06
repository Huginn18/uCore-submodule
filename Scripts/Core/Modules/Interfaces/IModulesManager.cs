namespace HoodedCrow.uCore.Core
{
    public interface IModulesManager
    {
        TModule GetModule<TModule>() where TModule : IModule;
    }
}
