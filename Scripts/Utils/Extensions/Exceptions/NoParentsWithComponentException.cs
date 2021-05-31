namespace HoodedCrow.uCore.Utils
{
    using System;

    public class NoParentsWithComponentException: Exception
    {
        public NoParentsWithComponentException(string message): base(message)
        {
        }
    }
}
