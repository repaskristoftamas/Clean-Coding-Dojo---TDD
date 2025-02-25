using System;

namespace TDD_Coding_Dojo.Exceptions
{
    /// <summary>
    /// Thrown when any item exceeds the maximum allowed quantity.
    /// </summary>
    public class MaximumPurchaseException : Exception
    {
        public MaximumPurchaseException()
        {
        }

        public MaximumPurchaseException(string message)
            : base(message)
        {
        }

        public MaximumPurchaseException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
