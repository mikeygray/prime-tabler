using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeTabler.PrimeTablerModel
{

    /// <summary>
    /// An object for the calculation and storing of prime numbers and associated multiplcation table
    /// </summary>
    /// <remarks>
    /// Keeping the functionality tied here seemed the right choice for the problem (though a bit "Fat Model, Skinny Controller")
    /// </remarks>
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
        private long[,] _primesTable;

        public PrimesModel(int numberOfPrimes)
        {
            PopulatePrimes(numberOfPrimes);
        }

        /// <summary>
        /// Builds this objects list of sequential Prime Numbers starting with 2
        /// Also builds associated multiplication table
        /// </summary>
        /// <see cref="GetPrimeTableAt(int, int)"/>
        /// <remarks>
        /// I considered a few methods (https://en.wikipedia.org/wiki/Primality_test) but after conducting a few speed tests
        /// found this simple algorithm more than adquate given the relatively small numbers required.
        /// Calculating the primes is NOT the bottle neck for this application! For this reason also dismissed caching data.
        /// </remarks>
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
            _populatePrimeTable(numberOfPrimes);
            _calculationTime = (DateTime.Now).Subtract(startTime);
        }


        /// <summary>
        /// Returns position row x col of the multiplcation table, including headers
        /// Returns zero if there is no value at row x col
        /// </summary>
        /// <remarks>
        /// Due to the number of primes being capped as an int, the largest possible prime would be the 2,147,483,647th prime
        /// (an int's max value) which is is 50,685,770,143 (source https://primes.utm.edu/nthprime/index.php). This can be
        /// stored as a long (max value 9,223,372,036,854,775,807)
        /// </remarks>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public long GetPrimeTableAt(int row, int col)
        {
            try
            {
                return _primesTable[row, col];
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private void _populatePrimeTable(int numberOfPrimes)
        {
            if (numberOfPrimes > 0)
            {
                _primesTable = new long[numberOfPrimes + 1, numberOfPrimes + 1];
                _primesTable[0, 0] = -1;
                for (int x = 1; x <= numberOfPrimes; x++)
                {
                    _primesTable[x, 0] = _primes.ElementAt(x - 1);
                    _primesTable[0, x] = _primes.ElementAt(x - 1);

                    for (int y = 1; y <= numberOfPrimes; y++)
                    {
                        _primesTable[x, y] = (_primes.ElementAt(x - 1) * _primes.ElementAt(y - 1));
                    }
                }
            }
            else _primesTable = new long[0,0];
        }
    }
}