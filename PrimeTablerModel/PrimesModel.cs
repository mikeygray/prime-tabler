using System;
using System.Collections.Generic;

namespace PrimeTabler.PrimeTablerModel
{

    /// <summary>
    /// An object for the calculation and storing of prime numbers and associated multiplcation table
    /// </summary>
    public class PrimesModel
    {
        public List<long> Primes
        {
            get { return _primes; }
        }

        public TimeSpan CalculationTime
        {
            get { return _calculationTime; }
        }

        public int NumberOfPrimes
        {
            get { return _primes.Count; }
        }

        private List<long> _primes = new List<long>();
        private TimeSpan _calculationTime = new TimeSpan();

        public PrimesModel(int numberOfPrimes)
        {
            PopulatePrimes(numberOfPrimes);
        }

        /// <summary>
        /// Builds this objects list of sequential Prime Numbers starting with 2
        /// </summary>
        /// <param name="numberOfPrimes">i.e. 3 would populate {2,3,5}</param>
        public void PopulatePrimes(int numberOfPrimes)
        {
            _primes.Clear();
            var startTime = DateTime.Now;
            if (numberOfPrimes > 0) _primes.Add(2);
            long nextPrime = 3;

            while (Primes.Count < numberOfPrimes)
            {
                int sqrt = (int)Math.Sqrt(nextPrime);
                bool isPrime = true;
                for (int i = 0; _primes[i] <= sqrt; i++)
                {
                    if (nextPrime % _primes[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    _primes.Add(nextPrime);
                }
                nextPrime += 2;
            }
            _calculationTime = (DateTime.Now).Subtract(startTime);
        }
    }
}