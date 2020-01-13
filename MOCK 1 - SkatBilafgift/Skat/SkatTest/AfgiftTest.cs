using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skat;

namespace SkatTest
{
    [TestClass]
    public class AfgiftTest
    {
        [TestMethod]
        public void PersonbilUnder0()
        {
            // ARRANGE
            int pris = -1000;

            // ACT & ASSERT
            try
            {
                Afgift.BilAfgift(pris);
                Assert.Fail(); // If it gets to this line, no exception was thrown. 
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [TestMethod]
        public void PersonbilUnder200000()
        {
            // ARRANGE
            int pris = 150000;
            double expected = pris * 0.85;

            // ACT
            int actual = Afgift.BilAfgift(pris);

            // ASSERT
            Assert.AreEqual((int)expected, actual, "Are not equal");
        }

        [TestMethod]
        public void PersonbilOver200000()
        {
            // ARRANGE
            int pris = 250000;
            double expected = (pris * 1.50) - 130000;

            // ACT
            int actual = Afgift.BilAfgift(pris);

            // ASSERT
            Assert.AreEqual((int)expected, actual, "Are not equal");
        }

        [TestMethod]
        public void ElbilUnder0()
        {
            // ARRANGE
            int pris = -1000;

            // ACT & ASSERT
            try
            {
                Afgift.ElBilAfgift(pris);
                Assert.Fail(); // If it gets to this line, no exception was thrown.
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [TestMethod]
        public void ElbilUnder200000()
        {
            // ARRANGE
            int pris = 150000;
            double expected = (pris * 0.85) * 0.20;

            // ACT
            int actual = Afgift.ElBilAfgift(pris);

            // ASSERT
            Assert.AreEqual((int)expected, actual, "Are not equal");
        }

        [TestMethod]
        public void ElbilOver200000()
        {
            // ARRANGE
            int pris = 250000;
            double expected = ((pris * 1.50) - 130000) * 0.20;

            // ACT
            int actual = Afgift.ElBilAfgift(pris);

            // ARRANGE
            Assert.AreEqual((int)expected, actual, "Are not equal");
        }
    }
}
