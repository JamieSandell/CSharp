using System;
using static System.Console;

namespace Exercise_3._3___Practise_Loops_and_Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 100; i++)
            {
                if(i % 15 == 0)
                {
                    Write("Fizzbuzz ");
                }
                else if(i % 3 == 0)
                {
                    Write("Fizz ");
                }
                else if(i % 5 == 0)
                {
                    Write("Buzz ");
                }
                else
                {
                    Write($"{i} ");
                }
            }
        }
    }
}
