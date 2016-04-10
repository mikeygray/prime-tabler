using PrimeTabler.PrimeTablerModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PrimeTabler.PrimeTablerTest
{
    [TestClass]
    public class PrimeModelTest
    {
        /* Negative Input */
        [TestMethod]
        public void WhenConstructorNegative_ShouldPopulateNoPrimes()
        {
            var primes = new PrimesModel(-1);
            CollectionAssert.AreEqual(new List<long> { }, primes.Primes);
            Assert.AreEqual(0, primes.NumberOfPrimes);

            primes = new PrimesModel(-500);
            CollectionAssert.AreEqual(new List<long> { }, primes.Primes);
            Assert.AreEqual(0, primes.NumberOfPrimes);
        }

        [TestMethod]
        public void WhenPopulatePrimesNegative_ShouldPopulateNoPrimes()
        {
            var primes = new PrimesModel(3);
            primes.PopulatePrimes(-1);
            CollectionAssert.AreEqual(new List<long> { }, primes.Primes);
            Assert.AreEqual(0, primes.NumberOfPrimes);

            primes = new PrimesModel(7);
            primes.PopulatePrimes(-239);
            CollectionAssert.AreEqual(new List<long> { }, primes.Primes);
            Assert.AreEqual(0, primes.NumberOfPrimes);
        }

        /* Zero Input */
        [TestMethod]
        public void WhenConstructorZero_ShouldPopulateNoPrimes()
        {
            var primes = new PrimesModel(0);
            CollectionAssert.AreEqual(new List<long> { }, primes.Primes);
            Assert.AreEqual(0, primes.NumberOfPrimes);
        }

        [TestMethod]
        public void WhenPopulatePrimesZero_ShouldPopulateNoPrimes()
        {
            var primes = new PrimesModel(4);
            primes.PopulatePrimes(0);
            CollectionAssert.AreEqual(new List<long> { }, primes.Primes);
            Assert.AreEqual(0, primes.NumberOfPrimes);
        }

        /* Positive Input */
        [TestMethod]
        public void WhenConstructor1Prime_ShouldPopulateAppropiately()
        {
            var primes = new PrimesModel(1);
            CollectionAssert.AreEqual(new List<long> { 2 }, primes.Primes);
            Assert.AreEqual(1, primes.NumberOfPrimes);
        }

        [TestMethod]
        public void WhenPopulatePrimes1Prime_ShouldPopulateAppropiately()
        {
            var primes = new PrimesModel(13);
            primes.PopulatePrimes(1);
            CollectionAssert.AreEqual(new List<long> { 2 }, primes.Primes);
            Assert.AreEqual(1, primes.NumberOfPrimes);
        }

        [TestMethod]
        public void WhenConstructor3Prime_ShouldPopulateAppropiately()
        {
            var primes = new PrimesModel(3);
            CollectionAssert.AreEqual(new List<long> { 2, 3, 5 }, primes.Primes);
            Assert.AreEqual(3, primes.NumberOfPrimes);
        }

        [TestMethod]
        public void WhenPopulatePrimes3Prime_ShouldPopulateAppropiately()
        {
            var primes = new PrimesModel(0);
            primes.PopulatePrimes(3);
            CollectionAssert.AreEqual(new List<long> { 2, 3, 5 }, primes.Primes);
            Assert.AreEqual(3, primes.NumberOfPrimes);
        }

        [TestMethod]
        public void WhenConstructor10Prime_ShouldPopulateAppropiately()
        {
            var primes = new PrimesModel(10);
            CollectionAssert.AreEqual(new List<long> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 }, primes.Primes);
            Assert.AreEqual(10, primes.NumberOfPrimes);
        }

        [TestMethod]
        public void WhenPopulatePrimes10Prime_ShouldPopulateAppropiately()
        {
            var primes = new PrimesModel(-5);
            primes.PopulatePrimes(10);
            CollectionAssert.AreEqual(new List<long> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 }, primes.Primes);
            Assert.AreEqual(10, primes.NumberOfPrimes);
        }

        /* Calculation Time */
        [TestMethod]
        public void WhenCalculating1000Primes_ShouldHaveCalculationTimeOverZero()
        {
            var primes = new PrimesModel(1000);
            Assert.IsTrue(primes.CalculationTime.TotalSeconds > 0);
        }
    }
}
