using System;

namespace TDD_Coding_Dojo.Exceptions
{
    /// <summary>
    /// Thrown when any item is below the minimum required quantity.
    /// </summary>
    public class MinimumPurchaseException : Exception
    {
        public MinimumPurchaseException()
        {
        }

        public MinimumPurchaseException(string message)
            : base(message)
        {
        }

        public MinimumPurchaseException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
