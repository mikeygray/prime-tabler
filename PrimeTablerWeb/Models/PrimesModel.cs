using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrimeTablerWeb.Models
{
    public class PrimesModel
    {
        public ReadOnlyCollection<int> Primes
        {
            get { return _primes.AsReadOnly(); }
        }

        public TimeSpan CalculationTime
        {
            get { return _calculationTime; }
        }

        public int NumberOfPrimes
        {
            get { return _primes.Count; }
        }
           
        private List<int> _primes = new List<int>();
        private TimeSpan _calculationTime = new TimeSpan();
        private ulong[,] _primesTable;

        public PrimesModel(int numberOfPrimes)
        {
            PopulatePrimes(numberOfPrimes);
        }

        /*
            Explanation of method used
            Internal Discussion of where in MVC pattern to place population method
            */
        public void PopulatePrimes(int numberOfPrimes)
        {
            _primes.Clear();
            var startTime = DateTime.Now;
            if(numberOfPrimes > 0) _primes.Add(2);
            int nextPrime = 3;

            while (Primes.Count < numberOfPrimes)
            {
                int sqrt = (int)Math.Sqrt(nextPrime);
                bool isPrime = true;
                for (int i = 0; Primes[i] <= sqrt; i++)
                {
                    if (nextPrime % Primes[i] == 0)
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

        public ulong GetPrimeTableAt(int row, int col)
        {
            try {
                return _primesTable[row, col];
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
        private void _populatePrimeTable(int numberOfPrimes)
        {
            if (numberOfPrimes > 0)
            {
                _primesTable = new ulong[numberOfPrimes+1, numberOfPrimes+1];
                _primesTable[0, 0] = 0;
                for (int x = 1; x <= numberOfPrimes; x++)
                {
                    _primesTable[x, 0] = (ulong)_primes.ElementAt(x-1);
                    _primesTable[0, x] = (ulong)_primes.ElementAt(x-1);

                    for (int y = 1; y <= numberOfPrimes; y++)
                    {
                        _primesTable[x, y] = (ulong)(_primes.ElementAt(x-1) * _primes.ElementAt(y-1));
                    }
                }
            }
        }
    }
}