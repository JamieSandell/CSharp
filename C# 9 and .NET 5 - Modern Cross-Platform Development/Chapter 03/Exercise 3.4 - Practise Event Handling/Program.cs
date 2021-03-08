using System;
using static System.Console;
using static System.Convert;

namespace Exercise_3._4___Practise_Event_Handling
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter a number between 0 and 255: ");
            string input = ReadLine();
            byte firstNumber = 0;
            try
            {
                checked
                {
                    firstNumber = ToByte(input);
                }
                
            }
            catch(FormatException)
            {
                Console.WriteLine($"{input} is not in a valid format 0 - 255");
            }
            catch(OverflowException)
            {
                Console.WriteLine($"Overflow caught");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            Write("Enter another number between 0 and 255: ");
            input = ReadLine();
            byte secondNumber = 0;
            try
            {
                checked
                {
                    secondNumber = ToByte(input);
                }
                
            }
            catch(FormatException)
            {
                WriteLine($"{input} is not in a valid format 0 - 255");
            }
            catch(OverflowException)
            {
                WriteLine($"Overflow caught");
            }
            catch(Exception ex)
            {
                WriteLine($"{ex.Message}");
            }


            try
            {
                WriteLine($"{firstNumber / secondNumber}");
            }
            catch(DivideByZeroException)
            {
                WriteLine("Caught divide by zero exception");
            }
            catch(Exception ex)
            {
                WriteLine($"{ex.Message}");
            }
        }
    }
}
