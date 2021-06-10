namespace HoodedCrow.uCore.Core
{
    using System;

    public class UnknownModuleTypeException: Exception
    {
        public UnknownModuleTypeException(string message): base(message)
        {
        }
    }
}
