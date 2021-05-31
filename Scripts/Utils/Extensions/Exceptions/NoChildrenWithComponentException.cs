namespace HoodedCrow.uCore.Utils
{
    using System;

    public class NoChildrenWithComponentException: Exception
    {
        public NoChildrenWithComponentException(string message): base(message)
        {

        }
    }
}
