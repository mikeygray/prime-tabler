using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTabler.PrimeTablerConsole
{
    /// <summary>
    /// Returns valid int from user input string
    /// Return -1 flag if unsuccessful
    /// </summary>
    public class PrimeConsoleHelper
    {
        public int ValidateInput(string input)
        {
            int intResult = -1;
            bool inputSuccess = int.TryParse(input, out intResult);
            if (intResult < 1 || string.IsNullOrWhiteSpace(input) || !inputSuccess)
            {
                intResult = -1;
            }
            return intResult;
        } 
    }
}
