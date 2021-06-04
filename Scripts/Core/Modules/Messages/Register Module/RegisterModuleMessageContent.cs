namespace HoodedCrow.uCore.Core
{
    public struct RegisterModuleMessageContent: IMessageContent
    {
        public IModule Module;

        public RegisterModuleMessageContent(IModule module)
        {
            Module = module;
        }
    }
}
