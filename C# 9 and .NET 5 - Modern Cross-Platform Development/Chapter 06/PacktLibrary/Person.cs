using System;
using static System.Console;
using System.Collections.Generic;

namespace Packt.Shared
{
    public class Person
    {
        // fields
        public string Name;
        public DateTime DateOfBirth;
        public List<Person> Children = new List<Person>();

        // instance methods
        public Person ProcreateWith(Person partner)
        {
            return Procreate(this, partner);
        }
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}");
        }

        // static methods
        public static Person operator*(Person p1, Person p2)
        {
            return Procreate(p1, p2);
        }
        public static Person Procreate(Person p1, Person p2)
        {
            var baby = new Person
            {
                Name = $"Baby of {p1.Name} and {p2.Name}"
            };

            p1.Children.Add(baby);
            p2.Children.Add(baby);

            return baby;
        }
    }
}
