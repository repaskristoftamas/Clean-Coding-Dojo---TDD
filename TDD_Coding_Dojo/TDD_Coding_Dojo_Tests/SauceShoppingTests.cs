using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TDD_Coding_Dojo;
using TDD_Coding_Dojo.Exceptions;

namespace TDD_Coding_Dojo_Tests
{
    [TestClass]
    public class SauceShoppingTests
    {
        private readonly SauceShopping _shop = new SauceShopping();

        [DataTestMethod]
        [DataRow(1, 1, 1, "A:1 B:1 C:1")]
        [DataRow(10, 20, 30, "A:10 B:20 C:30")]
        [DataRow(100, 100, 100, "A:100 B:100 C:100")]
        public void Purchase_ReturnsFormattedString_WhenQuantitiesAreValid(int ketchup, int mustard, int mayonnaise, string expected)
        {
            string actual = _shop.Purchase(ketchup, mustard, mayonnaise);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(0, 10, 10)]
        [DataRow(10, 0, 10)]
        [DataRow(10, 10, 0)]
        public void Purchase_ThrowsMinimumPurchaseException_WhenInputIsBelowMinimum(int ketchup, int mustard, int mayonnaise)
        {
            Assert.ThrowsException<MinimumPurchaseException>(() => _shop.Purchase(ketchup, mustard, mayonnaise));
        }

        [DataTestMethod]
        [DataRow(101, 101, 101)]
        [DataRow(101, 100, 100)]
        [DataRow(100, 101, 100)]
        [DataRow(100, 100, 101)]
        public void Purchase_ThrowsMaximumPurchaseException_WhenInputIsAboveMaximum(int ketchup, int mustard, int mayonnaise)
        {
            Assert.ThrowsException<MaximumPurchaseException>(() => _shop.Purchase(ketchup, mustard, mayonnaise));
        }

        [DataTestMethod]
        [DynamicData(nameof(AmountTestData))]
        public void Amount_CalculatesDiscount_WhenAmountIsValid(int ketchup, int mustard, int mayonnaise, double expected)
        {
            int actual = _shop.Amount(ketchup, mustard, mayonnaise);
            Assert.AreEqual((int)expected, actual);
        }

        public static IEnumerable<object[]> AmountTestData
        {
            get
            {
                yield return new object[] { 0, 0, 1, 0 * 100 + 0 * 100 + 1 * 250 };
                yield return new object[] { 1, 1, 1, 1 * 100 + 1 * 200 + 1 * 250 };
                yield return new object[] { 24, 24, 24, 24 * 100 + 24 * 200 + 24 * 250 };
                yield return new object[] { 25, 25, 25, (25 * 100 + 25 * 200 + 25 * 250) * 0.9 };
                yield return new object[] { 49, 49, 49, (49 * 100 + 49 * 200 + 49 * 250) * 0.9 };
                yield return new object[] { 50, 50, 50, (50 * 100 + 50 * 200 + 50 * 250) * 0.75 };
            }
        }
    }
}
