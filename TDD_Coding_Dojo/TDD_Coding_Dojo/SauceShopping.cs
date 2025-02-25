using System;
using TDD_Coding_Dojo.Exceptions;

namespace TDD_Coding_Dojo
{
    /// <summary>
    /// Class for sauce shopping.
    /// </summary>
    public class SauceShopping
    {
        private readonly int _ketchupPrice = 100;
        private readonly int _mustardPrice = 200;
        private readonly int _mayonnaisePrice = 250;

        /// <summary>
        /// Calculates the total cost of purchasing ketchup, mustard, and mayonnaise, applying discounts based on quantity.
        /// </summary>
        /// <param name="ketchup">The quantity of ketchup being purchased.</param>
        /// <param name="mustard">The quantity of mustard being purchased.</param>
        /// <param name="mayonnaise">The quantity of mayonnaise being purchased.</param>
        /// <returns>The total cost after applying any applicable discounts.</returns>
        public int Amount(int ketchup, int mustard, int mayonnaise)
        {
            if (ketchup >= 50 || mustard >= 50 || mayonnaise >= 50)
            {
                return (int)((ketchup * _ketchupPrice + mustard * _mustardPrice + mayonnaise * _mayonnaisePrice) * 0.75);
            }
            else if (ketchup >= 25 || mustard >= 25 || mayonnaise >= 25)
            {
                return (int)((ketchup * _ketchupPrice + mustard * _mustardPrice + mayonnaise * _mayonnaisePrice) * 0.9);
            }
            else
            {
                return ketchup * _ketchupPrice + mustard * _mustardPrice + mayonnaise * _mayonnaisePrice;
            }
        }

        /// <summary>
        /// Processes a purchase order for ketchup, mustard, and mayonnaise.
        /// Validates that the quantities are within the allowed range.
        /// Throws a MinimumPurchaseException if any item is below the minimum requirement.
        /// Throws a MaximumPurchaseException if any item exceeds the maximum limit.
        /// Calculates the total amount and returns a summary of the purchase.
        /// </summary>
        /// <param name="ketchup">The quantity of ketchup to purchase.</param>
        /// <param name="mustard">The quantity of mustard to purchase.</param>
        /// <param name="mayonnaise">The quantity of mayonnaise to purchase.</param>
        /// <returns>A formatted string summarizing the quantities purchased.</returns>
        /// <exception cref="MinimumPurchaseException">Thrown when any item is below the minimum required quantity.</exception>
        /// <exception cref="MaximumPurchaseException">Thrown when any item exceeds the maximum allowed quantity.</exception>
        public string Purchase(int ketchup, int mustard, int mayonnaise)
        {
            if (ketchup <= 0 || mustard <= 0 || mayonnaise <= 0)
            {
                throw new MinimumPurchaseException("You must buy at least 10 of each!");
            }
            else if (ketchup > 100 || mustard > 100 || mayonnaise > 100)
            {
                throw new MaximumPurchaseException("You cannot buy more than 100 of anything!");
            }
            else
            {
                int amount = Amount(ketchup, mustard, mayonnaise);
                Console.WriteLine(amount);
                return $"A:{ketchup} B:{mustard} C:{mayonnaise}";
            }
        }
    }
}
