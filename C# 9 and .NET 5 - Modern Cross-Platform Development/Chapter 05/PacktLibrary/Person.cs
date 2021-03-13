using System;
using static System.Console;
using System.Collections.Generic;

namespace Packt.Shared
{
    public partial class Person
    {
        // fields
        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheAncientWorld FavouriteAncientWonder;
        public WondersOfTheAncientWorld BucketList;
        public List<Person> Children = new List<Person>();
        // constants
        /*Constants should be avoided for two important reasons: the
            value must be known at compile time, and it must be expressible as a literal
            string, Boolean, or number value. Every reference to the const field is replaced
            with the literal value at compile time, which will, therefore, not be reflected if
            the value changes in a future version and you do not recompile any assemblies
            that reference it to get the new value.*/
        public const string Species = "Homo Sapien";
        // read only fields
        /*Use read-only fields over constant fields for two important
            reasons: the value can be calculated or loaded at runtime and can be
            expressed using any executable statement. So, a read-only field can be set
            using a constructor or a field assignment. Every reference to the field is a live
            reference, so any future changes will be correctly reflected by calling code.*/
        public readonly string HomePlanet = "Earth";
        public readonly DateTime Instantiated;

        // constructors
        public Person()
        {
            // set default values for fields including read-only fields
            Name = "unknown";
            Instantiated = DateTime.Now;
        }

        public Person(string initialName, string homePlanet)
        {
            Name = initialName;
            HomePlanet = homePlanet;
            Instantiated = DateTime.Now;
        }

        // methods
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
        }

        public (string, int) GetFruit()
        {
            return ("Apples", 5);
        }

        public string GetOrigin()
        {
            return $"{Name} was born on {HomePlanet}.";
        }

        public (string Name, int Number) GetNamedFruit()
        {
            return (Name: "Apples", Number: 5);
        }

        public string OptionalParameters(
            string command = "Run!",
            double number = 0.0,
            bool active = true)
        {
            return string.Format(
                format: "command is {0}, number is {1}, active is {2}",
                arg0: command, arg1: number, arg2: active
            );
        }

        public void PassingParameters(int x, ref int y, out int z)
        {
            // out parameters cannot have a default and must be initialised inside the method
            z = 99;

            x++;
            y++;
            z++;
        }

        public string SayHello()
        {
            return $"{Name} says 'Hello!'";
        }

        public string SayHello(string name)
        {
            return $"{Name} says 'Hello {name}!";
        }
    }
}
