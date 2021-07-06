namespace HoodedCrow.uCore.Core
{
    using System;

    public class ModuleDuplicateException: Exception
    {
        public ModuleDuplicateException(string message): base(message)
        {
        }
    }
}
