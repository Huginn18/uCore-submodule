namespace HoodedCrow.uCore.Core
{
    using System;

    public class UnknownPoolElementTypeException: Exception
    {
        public UnknownPoolElementTypeException(string message): base(message)
        {
        }
    }
}
