using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_Coding_Dojo;
using TDD_Coding_Dojo.Exceptions;

namespace TDD_Coding_Dojo_Tests
{
    [TestClass]
    public class SauceShoppingTests
    {
        [TestMethod()]
        public void Purchase_ReturnsFormattedString_WhenQuantitiesAreValid()
        {
            int ketchup = 1;
            int mustard = 5;
            int mayonnaise = 6;
            SauceShopping shop = new SauceShopping();

            string expected = "A:1 B:5 C:6";
            string actual = shop.Purchase(ketchup, mustard, mayonnaise);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Purchase_ThrowsMinimumPurchaseException_WhenKetchupIsNegative()
        {
            int ketchup = -1;
            int mustard = 5;
            int mayonnaise = 6;
            SauceShopping shop = new SauceShopping();

            Assert.ThrowsException<MinimumPurchaseException>(() => shop.Purchase(ketchup, mustard, mayonnaise));
        }

        [TestMethod()]
        public void Purchase_ThrowsMinimumPurchaseException_WhenMustardIsNegative()
        {
            int ketchup = 1;
            int mustard = -5;
            int mayonnaise = 6;
            SauceShopping shop = new SauceShopping();

            Assert.ThrowsException<MinimumPurchaseException>(() => shop.Purchase(ketchup, mustard, mayonnaise));
        }

        [TestMethod()]
        public void Purchase_ThrowsMinimumPurchaseException_WhenMayonnaiseIsNegative()
        {
            int ketchup = 1;
            int mustard = 5;
            int mayonnaise = -6;
            SauceShopping shop = new SauceShopping();

            Assert.ThrowsException<MinimumPurchaseException>(() => shop.Purchase(ketchup, mustard, mayonnaise));
        }


        [TestMethod()]
        public void Purchase_ThrowsMinimumPurchaseException_WhenEverythingIsBelowMinimum()
        {
            int ketchup = 0;
            int mustard = 0;
            int mayonnaise = 0;
            SauceShopping shop = new SauceShopping();

            Assert.ThrowsException<MinimumPurchaseException>(() => shop.Purchase(ketchup, mustard, mayonnaise));
        }

        [TestMethod()]
        public void Purchase_ThrowsMaximumPurchaseException_WhenSomethingIsMoreThanMaximum()
        {
            int ketchup = 101;
            int mustard = 5;
            int mayonnaise = 5;
            SauceShopping shop = new SauceShopping();

            Assert.ThrowsException<MaximumPurchaseException>(() => shop.Purchase(ketchup, mustard, mayonnaise));
        }

        [TestMethod()]
        public void Purchase_DoesNotThrowException_WhenQuantitiesAreAtMinimum()
        {
            int ketchup = 1;
            int mustard = 1;
            int mayonnaise = 1;
            SauceShopping shop = new SauceShopping();

            string actual = shop.Purchase(ketchup, mustard, mayonnaise);
            string expected = "A:1 B:1 C:1";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Amount_CalculatesDiscount_WhenAmountIsMinimum()
        {
            int ketchup = 1;
            int mustard = 1;
            int mayonnaise = 1;
            SauceShopping shop = new SauceShopping();
            int elvart = 1 * 100 + 1 * 200 + 1 * 250;
            int kapott = shop.Amount(ketchup, mustard, mayonnaise);
            Assert.AreEqual(elvart, kapott);
        }

        [TestMethod()]
        public void Amount_CalculatesDiscount_WhenAmountIsGreaterThan25()
        {
            int ketchup = 25;
            int mustard = 25;
            int mayonnaise = 25;
            SauceShopping shop = new SauceShopping();
            int elvart = (int)((25 * 100 + 25 * 200 + 25 * 250) * 0.9);
            int kapott = shop.Amount(ketchup, mustard, mayonnaise);
            Assert.AreEqual(elvart, kapott);
        }

        [TestMethod()]
        public void Amount_CalculatesDiscount_WhenAmountIsGreaterThan50()
        {
            int ketchup = 50;
            int mustard = 1;
            int mayonnaise = 1;
            SauceShopping shop = new SauceShopping();
            int elvart = (int)((50 * 100 + 1 * 200 + 1 * 250) * 0.75);
            int kapott = shop.Amount(ketchup, mustard, mayonnaise);
            Assert.AreEqual(elvart, kapott);
        }
    }
}
