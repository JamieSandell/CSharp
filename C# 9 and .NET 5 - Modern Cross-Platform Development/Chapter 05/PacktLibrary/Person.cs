using System;
using static System.Console;
using System.Collections.Generic;

namespace Packt.Shared
{
    public class Person : System.Object
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
    }
}
