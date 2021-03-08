//Practice writing functions with debugging and unit testing
using Packt;
using System;
using static System.Console;

namespace Exercise_4._2
{
    class Program
    {
        static void RunPrimeFactors(int number)
        {
            var pf = new PrimeFactorsLib();
            Console.WriteLine($"The prime factors of {number} are: {pf.PrimeFactors(number)}");
        }
        static void Main(string[] args)
        {
            var pf = new PrimeFactorsLib();
            for(int i = 2; i <= 50; i++)
            {
                RunPrimeFactors(i);
            }
        }
    }
}
