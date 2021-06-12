namespace HoodedCrow.uCore.Core
{
    using System;

    public class UnknownSavableTypeException: Exception
    {
        public UnknownSavableTypeException(string message): base(message)
        {

        }
    }
}
