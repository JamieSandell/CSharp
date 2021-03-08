﻿using System;
using System.IO;
using System.Xml;

namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            object height = 1.88; // storing a double in an object
            object name = "Amir"; // storing a string in an object
            Console.WriteLine($"{name} is {height} metres tall.");

            //int length1 = name.Length; // gives compile error
            int length2 = ((string)name).Length; // tell compiler it is a string
            Console.WriteLine($"{name} has {length2} characters.");

            dynamic anotherName = "Ahmed"; // storing a string in a dynamic object
            // This compiles but would generate an error at run-time if you later
            // store a data type that does not have a property named Length
            int length = anotherName.Length;

            var population = 66_000_000; // 66 million in UK
            var weight = 1.88; // in kilograms
            var price = 4.99M; // in pounds sterling
            var fruit = "Apples"; // strings use double quotes
            var letter = 'Z'; // chars use single-quotes
            var happy = true; // Booleans have value of true or false

            // good use of var because it avoids the repeated type
            // as shown in the more verbose second statement
            var xml1  = new XmlDocument();
            XmlDocument xml2 = new XmlDocument();

            // bad use of var because we cannot tell the type, so we
            // should use a specific type declaration as shown in
            // the second statement
            var file1 = File.CreateText(@"C:\temp\something.txt");
            StreamWriter file2 = File.CreateText(@"C:\temp\something2.txt");

            XmlDocument xml3 = new(); // target-typed in C# 9

            Console.WriteLine($"default(int) = {default(int)}");
            Console.WriteLine($"default (bool) = {default(bool)}");
            Console.WriteLine($"default(DateTime) = {default(DateTime)}");
            Console.WriteLine($"default(string) = {default(string)}");
        }
    }
}
