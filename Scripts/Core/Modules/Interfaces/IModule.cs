namespace HoodedCrow.uCore.Core
{
    public interface IModule
    {
        void Initialize(IModuleManager moduleManager);
        void Uninitialize();
    }
}
