using System;
using static System.Console;

namespace Exercise_3._2__Explorer_Loops_and_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            checked
            {
                try
                {
                    int max = 500;
                    for (byte i = 0; i < max; i++)
                    {
                        WriteLine(i);
                    }
                }
                catch (OverflowException)
                {
                    WriteLine("The code has overflowed.");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
    }
}
