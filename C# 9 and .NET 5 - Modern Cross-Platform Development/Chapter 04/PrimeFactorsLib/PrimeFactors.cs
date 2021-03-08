using System;
using System.Collections.Generic;

namespace Packt
{
    public class PrimeFactorsLib
    {
        /// <summary>
        /// Calculates the prime factors of a number.
        /// Assumes the largest number entered is a 1000.
        /// From http://csharphelper.com/blog/2014/07/find-a-numbers-prime-factors-in-c/
        /// </summary>
        /// <param name="number">The number to perform the calculation on.</param>
        /// <returns>A string containing the prime factors of the number.</returns>
        public string PrimeFactors(int number)
        {
            List<int> result = new List<int>();

            // Take out the 2s.
            while (number % 2 == 0)
            {
                result.Add(2);
                number /= 2;
            }

            // Take out other primes.
            int factor = 3;
            while (factor * factor <= number)
            {
                if (number % factor == 0)
                {
                    // This is a factor.
                    result.Add(factor);
                    number /= factor;
                }
                else
                {
                    // Go to the next odd number.
                    factor += 2;
                }
            }

            // If num is not 1, then whatever is left is prime.
            if (number > 1) result.Add(number);
            List<string> strings = result.ConvertAll(x => x.ToString());
            return string.Join(" x ", strings.ToArray());
        }
    }
}
