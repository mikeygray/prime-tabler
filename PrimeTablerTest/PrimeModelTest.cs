using PrimeTabler.PrimeTablerModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PrimeTabler.PrimeTablerTest
{
    [TestClass]
    public class PrimeModelTest
    {
        int[,] expected11x11PrimesTable;

        [TestInitialize()]
        public void Initialize()
        {
            /* 11 x 11 expected output for a primes multiplication table */
            expected11x11PrimesTable = new int[,] {     { -1, 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 },
                                                        { 2, 4, 6, 10, 14, 22, 26, 34, 38, 46, 58 },
                                                        { 3, 6, 9, 15, 21, 33, 39, 51, 57, 69, 87 },
                                                        { 5, 10, 15, 25, 35, 55, 65, 85, 95, 115, 145 },
                                                        { 7, 14, 21, 35, 49, 77, 91, 119, 133, 161, 203 },
                                                        { 11, 22, 33, 55, 77, 121, 143, 187, 209, 253, 319 },
                                                        { 13, 26, 39, 65, 91, 143, 169, 221, 247, 299, 377 },
                                                        { 17, 34, 51, 85, 119, 187, 221, 289, 323, 391, 493 },
                                                        { 19, 38, 57, 95, 133, 209, 247, 323, 361, 437, 551 },
                                                        { 23, 46, 69, 115, 161, 253, 299, 391, 437, 529, 667 },
                                                        { 29, 58, 87, 145, 203, 319, 377, 493, 551, 667, 841 }
            };
        }

        /* Negative Input */
        [TestMethod]
        public void WhenConstructorNegative_ShouldPopulateNoPrimes()
        {
            var primes = new PrimesModel(-1);
            CollectionAssert.AreEqual(new List<long> { }, primes.Primes);
            Assert.AreEqual(0, primes.NumberOfPrimes);
            Assert.AreEqual(0, primes.GetPrimeTableAt(0, 0));

            primes = new PrimesModel(-500);
            CollectionAssert.AreEqual(new List<long> { }, primes.Primes);
            Assert.AreEqual(0, primes.NumberOfPrimes);
            Assert.AreEqual(0, primes.GetPrimeTableAt(1, 2));
        }

        [TestMethod]
        public void WhenPopulatePrimesNegative_ShouldPopulateNoPrimes()
        {
            var primes = new PrimesModel(3);
            primes.PopulatePrimes(-1);
            CollectionAssert.AreEqual(new List<long> { }, primes.Primes);
            Assert.AreEqual(0, primes.NumberOfPrimes);
            Assert.AreEqual(0, primes.GetPrimeTableAt(0, 1));

            primes = new PrimesModel(7);
            primes.PopulatePrimes(-239);
            CollectionAssert.AreEqual(new List<long> { }, primes.Primes);
            Assert.AreEqual(0, primes.NumberOfPrimes);
            Assert.AreEqual(0, primes.GetPrimeTableAt(3, 0));
        }

        /* Zero Input */
        [TestMethod]
        public void WhenConstructorZero_ShouldPopulateNoPrimes()
        {
            var primes = new PrimesModel(0);
            CollectionAssert.AreEqual(new List<long> { }, primes.Primes);
            Assert.AreEqual(0, primes.NumberOfPrimes);
            Assert.AreEqual(0, primes.GetPrimeTableAt(2, 2));
        }

        [TestMethod]
        public void WhenPopulatePrimesZero_ShouldPopulateNoPrimes()
        {
            var primes = new PrimesModel(4);
            primes.PopulatePrimes(0);
            CollectionAssert.AreEqual(new List<long> { }, primes.Primes);
            Assert.AreEqual(0, primes.NumberOfPrimes);
            Assert.AreEqual(0, primes.GetPrimeTableAt(3, 2));
        }

        /* Positive Input */
        [TestMethod]
        public void WhenConstructor1Prime_ShouldPopulateAppropiately()
        {
            var primes = new PrimesModel(1);
            CollectionAssert.AreEqual(new List<long> { 2 }, primes.Primes);
            Assert.AreEqual(1, primes.NumberOfPrimes);
            Assert.AreEqual(expected11x11PrimesTable[1,1], primes.GetPrimeTableAt(1, 1));
        }

        [TestMethod]
        public void WhenPopulatePrimes1Prime_ShouldPopulateAppropiately()
        {
            var primes = new PrimesModel(13);
            primes.PopulatePrimes(1);
            CollectionAssert.AreEqual(new List<long> { 2 }, primes.Primes);
            Assert.AreEqual(1, primes.NumberOfPrimes);
            Assert.AreEqual(expected11x11PrimesTable[0, 1], primes.GetPrimeTableAt(0, 1));
        }

        [TestMethod]
        public void WhenConstructor3Prime_ShouldPopulateAppropiately()
        {
            var primes = new PrimesModel(3);
            CollectionAssert.AreEqual(new List<long> { 2, 3, 5 }, primes.Primes);
            Assert.AreEqual(3, primes.NumberOfPrimes);
            Assert.AreEqual(expected11x11PrimesTable[1, 2], primes.GetPrimeTableAt(1, 2));
        }

        [TestMethod]
        public void WhenPopulatePrimes3Prime_ShouldPopulateAppropiately()
        {
            var primes = new PrimesModel(0);
            primes.PopulatePrimes(3);
            CollectionAssert.AreEqual(new List<long> { 2, 3, 5 }, primes.Primes);
            Assert.AreEqual(3, primes.NumberOfPrimes);
            Assert.AreEqual(expected11x11PrimesTable[2, 1], primes.GetPrimeTableAt(2, 1));
        }

        [TestMethod]
        public void WhenConstructor10Prime_ShouldPopulateAppropiately()
        {
            var primes = new PrimesModel(10);
            CollectionAssert.AreEqual(new List<long> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 }, primes.Primes);
            Assert.AreEqual(10, primes.NumberOfPrimes);
            Assert.AreEqual(expected11x11PrimesTable[3, 2], primes.GetPrimeTableAt(3, 2));
            Assert.AreEqual(expected11x11PrimesTable[4, 7], primes.GetPrimeTableAt(4, 7));
            Assert.AreEqual(expected11x11PrimesTable[9, 9], primes.GetPrimeTableAt(9, 9));
        }

        [TestMethod]
        public void WhenPopulatePrimes10Prime_ShouldPopulateAppropiately()
        {
            var primes = new PrimesModel(-5);
            primes.PopulatePrimes(10);
            CollectionAssert.AreEqual(new List<long> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 }, primes.Primes);
            Assert.AreEqual(10, primes.NumberOfPrimes);
            Assert.AreEqual(expected11x11PrimesTable[0, 1], primes.GetPrimeTableAt(0, 1));
            Assert.AreEqual(expected11x11PrimesTable[5, 3], primes.GetPrimeTableAt(5, 3));
            Assert.AreEqual(expected11x11PrimesTable[8, 9], primes.GetPrimeTableAt(8, 9));
        }

        /* Calculation Time */
        [TestMethod]
        public void WhenCalculating100Primes_ShouldHaveCalculationTimeOverZero()
        {
            var primes = new PrimesModel(100);
            Assert.IsTrue(primes.CalculationTime.TotalSeconds > 0);
        }
    }
}
