namespace HoodedCrow.uCore.Core
{
    public struct UnregisterModuleMessageContent: IMessageContent
    {
        public IModule Module;

        public UnregisterModuleMessageContent(IModule module)
        {
            Module = module;
        }
    }
}
