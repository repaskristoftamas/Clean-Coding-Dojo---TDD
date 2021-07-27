using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_Coding_Dojo;

namespace TDD_Coding_Dojo_Tests
{
    [TestClass]
    public class KiskereskedoBevasarlasTests
    {
        [TestMethod()]
        public void PurchaseSzovegTeszt()
        {
            int ketchupDB = 1;
            int mustarDB = 5;
            int majonezDB = 6;
            KiskereskedoBevasarlas vasarlas = new KiskereskedoBevasarlas();

            string elvart = "A:1B:5C:6";
            string kapott = vasarlas.Purchase(ketchupDB, mustarDB, majonezDB);
            Assert.AreEqual(elvart, kapott);
        }

        [TestMethod()]
        public void PurchaseTestNegativKetchup()
        {
            int ketchupDB = -1;
            int mustarDB = 5;
            int majonezDB = 6;
            KiskereskedoBevasarlas vasarlas = new KiskereskedoBevasarlas();
            Exception expectedExcetpion = null;

            try
            {
                vasarlas.Purchase(ketchupDB, mustarDB, majonezDB);
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }

            Assert.IsNotNull(expectedExcetpion);
        }

        [TestMethod()]
        public void PurchaseTestNegativMustar()
        {
            int ketchupDB = 1;
            int mustarDB = -5;
            int majonezDB = 6;
            KiskereskedoBevasarlas vasarlas = new KiskereskedoBevasarlas();
            Exception expectedExcetpion = null;

            try
            {
                vasarlas.Purchase(ketchupDB, mustarDB, majonezDB);
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }

            Assert.IsNotNull(expectedExcetpion);
        }

        [TestMethod()]
        public void PurchaseTestNegativMajonez()
        {
            int ketchupDB = 1;
            int mustarDB = 5;
            int majonezDB = -6;
            KiskereskedoBevasarlas vasarlas = new KiskereskedoBevasarlas();
            Exception expectedExcetpion = null;

            try
            {
                vasarlas.Purchase(ketchupDB, mustarDB, majonezDB);
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }

            Assert.IsNotNull(expectedExcetpion);
        }


        [TestMethod()]
        public void PurchaseTest0db()
        {
            int ketchupDB = 0;
            int mustarDB = 0;
            int majonezDB = 0;
            KiskereskedoBevasarlas vasarlas = new KiskereskedoBevasarlas();
            Exception expectedExcetpion = null;

            try
            {
                vasarlas.Purchase(ketchupDB, mustarDB, majonezDB);
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }

            Assert.IsNotNull(expectedExcetpion);
        }

        [TestMethod()]
        public void PurchaseTest100db()
        {
            int ketchupDB = 101;
            int mustarDB = 5;
            int majonezDB = 5;
            KiskereskedoBevasarlas vasarlas = new KiskereskedoBevasarlas();
            Exception expectedExcetpion = null;

            try
            {
                vasarlas.Purchase(ketchupDB, mustarDB, majonezDB);
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }

            Assert.IsNotNull(expectedExcetpion);
        }

        [TestMethod()]
        public void PurchaseTest1db()
        {
            int ketchupDB = 1;
            int mustarDB = 1;
            int majonezDB = 1;
            KiskereskedoBevasarlas vasarlas = new KiskereskedoBevasarlas();
            Exception expectedExcetpion = null;

            try
            {
                vasarlas.Purchase(ketchupDB, mustarDB, majonezDB);
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }

            Assert.IsNull(expectedExcetpion);
        }

        [TestMethod()]
        public void OsszegTeszt1db()
        {
            int ketchupDB = 1;
            int mustarDB = 1;
            int majonezDB = 1;
            KiskereskedoBevasarlas vasarlas = new KiskereskedoBevasarlas();
            int elvart = 1 * 100 + 1 * 200 + 1 * 250;
            int kapott = vasarlas.FizetendoOsszeg(ketchupDB, mustarDB, majonezDB);
            Assert.AreEqual(elvart, kapott);
        }

        [TestMethod()]
        public void OsszegTeszt50db()
        {
            int ketchupDB = 50;
            int mustarDB = 1;
            int majonezDB = 1;
            KiskereskedoBevasarlas vasarlas = new KiskereskedoBevasarlas();
            int elvart = (int)((50 * 100 + 1 * 200 + 1 * 250) * 0.75);
            int kapott = vasarlas.FizetendoOsszeg(ketchupDB, mustarDB, majonezDB);
            Assert.AreEqual(elvart, kapott);
        }

        [TestMethod()]
        public void OsszegTeszt25FelettiVasarlas()
        {
            int ketchupDB = 25;
            int mustarDB = 25;
            int majonezDB = 25;
            KiskereskedoBevasarlas vasarlas = new KiskereskedoBevasarlas();
            int elvart = (int)((25 * 100 + 25 * 200 + 25 * 250) * 0.9);
            int kapott = vasarlas.FizetendoOsszeg(ketchupDB, mustarDB, majonezDB);
            Assert.AreEqual(elvart, kapott);
        }
    }
}
