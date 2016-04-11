using System;
using PrimeTabler.PrimeTablerModel;

namespace PrimeTabler.PrimeTablerConsole
{
    class Program
    {
        static public void Main(string[] args)
        {
            Console.WriteLine(TextResources.Welcome);

            while(true)
            {
                int input = GetInput();
                var primeModel = new PrimesModel(input);

                if (primeModel.NumberOfPrimes > 0)
                {
                    for (int primeRow = 0; primeRow < primeModel.NumberOfPrimes; primeRow++)
                    {
                        for (int primeCol = 0; primeCol < primeModel.NumberOfPrimes; primeCol++)
                        {
                            Console.Write("| ");
                            if (primeModel.GetPrimeTableAt(primeRow, primeCol) > 0) Console.Write(primeModel.GetPrimeTableAt(primeRow, primeCol));
                            Console.Write("\t");
                        }
                        Console.WriteLine("|");
                    }
                }

                Console.WriteLine("Calculation Time: " + primeModel.CalculationTime.TotalSeconds + " secs");
                Console.WriteLine();
                Console.WriteLine(TextResources.Exit);
                var keyPressed = Console.ReadKey(true);
                if (keyPressed.KeyChar == 'y' || keyPressed.KeyChar == 'Y') break;
            }

        }

        static int GetInput()
        {
            PrimeConsoleHelper consoleHelper = new PrimeConsoleHelper();
            int input = -1;
            do
            {
                Console.Write(TextResources.Input);
                input = consoleHelper.ValidateInput(Console.ReadLine());
                if (input < 1 )
                    Console.WriteLine(TextResources.InputError);
                
            }
            while (input < 1);
            return input;
        }
    }
}
