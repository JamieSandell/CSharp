using Packt.Shared;
using System;
using static System.Console;
using System.Xml.Linq;


namespace AssembliesAndNamespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new XDocument();

            Write("Enter a colour value in hex: ");
            string hex = ReadLine();
            WriteLine($"Is {hex} a valid colour value? {hex.IsValidHex()}");

            Write("Enter an XML element: ");
            string xmlTag = ReadLine();
            WriteLine($"Is {xmlTag} a valid XML element? {xmlTag.IsValidXmlTag()}");

            Write("Enter a valid password: ");
            string password = ReadLine();
            WriteLine($"Is {password} a valid password? {password.IsValidPassword()}");
        }
    }
}
