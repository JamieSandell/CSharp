using System;
using static System.Console;
using System.Collections.Generic;

namespace Packt.Shared
{
    public class Person : IComparable<Person>
    {
        // data fields
        public string Name;
        public DateTime DateOfBirth;
        public List<Person> Children = new List<Person>();
        public int AngerLevel;

        // event delegate fields
        public event EventHandler Shout;

        // instance methods
        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                Shout?.Invoke(this, EventArgs.Empty); //if not null/something listening
            }
        }
        public Person ProcreateWith(Person partner)
        {
            return Procreate(this, partner);
        }

        public void TimeTravel(DateTime when)
        {
            if (when <= DateOfBirth)
            {
                throw new PersonException("If you travel back in time to before you were born, then the universe will explode!");
            }
            else
            {
                WriteLine($"Welcome to {when:yyyy}!");
            }
        }
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}");
        }

        // overridden methods
        public override string ToString()
        {
            return $"{Name} is a {base.ToString()}";
        }

        // static methods
        // method with a local function
        public static int Factorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"{nameof(number)} cannot be less than zero.");
            }

            return localFactorial(number);

            int localFactorial(int localNumber) // local function
            {
                if (localNumber < 1)
                {
                    return 1;
                }
                return localNumber * localFactorial(localNumber - 1);
            }
        }
        public static Person operator*(Person p1, Person p2)
        {
            return Procreate(p1, p2);
        }

        public static void Poke(Person p1)
        {
            p1.Poke();
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

        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
