namespace HoodedCrow.uCore.Core
{
    using System;

    public class SavableDuplicateException: Exception
    {
        public SavableDuplicateException(string message): base(message)
        {

        }
    }
}
