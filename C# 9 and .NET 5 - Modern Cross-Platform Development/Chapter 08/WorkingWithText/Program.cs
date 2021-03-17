using System;
using static System.Console;

namespace WorkingWithText
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = "London";
            WriteLine($"{city} is {city.Length} characters long.");
            WriteLine($"First char is {city[0]} and third is {city[2]}.");

            string cities = "Paris,Berlin,Madrid,New York";
            string[] citiesArray = cities.Split(',');
            foreach(string item in citiesArray)
            {
                WriteLine(item);
            }

            string fullName = "Alan Jones";
            int indexOfSpace = fullName.IndexOf(' ');
            string firstName = fullName.Substring(startIndex: 0, length: indexOfSpace);
            string surname = fullName.Substring(startIndex: indexOfSpace + 1);
            WriteLine($"{surname}, {firstName}");

            fullName = $"{surname}, {firstName}";
            int indexOfComma = fullName.IndexOf(',');
            surname = fullName.Substring(startIndex:0, length: indexOfComma);
            firstName = fullName.Substring(startIndex: indexOfComma + 2);
            WriteLine($"{firstName} {surname}");
        }
    }
}
