namespace HoodedCrow.uCore.UI
{
    using System;

    public class NotCurrentViewException: Exception
    {
        public NotCurrentViewException(string message): base(message)
        {

        }
    }
}
