using Packt.Shared;
using static System.Console;
using System;

namespace PeopleApp
{
    class Program
    {
        private static void Harry_Shout(object sender, EventArgs e) // Microsoft's convention for method names that handle events is ObjectName_EventName.
        {
            Person p = (Person)sender;
            WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
        }
        static void Main(string[] args)
        {
            var harry = new Person { Name = "Harry" };
            var mary = new Person { Name = "Mary" };
            var jill = new Person { Name = "Jill "};

            var baby1 = mary.ProcreateWith(harry);
            baby1.Name = "Gary";
            var baby2 = Person.Procreate(harry, jill);
            var baby3 = harry * mary;

            WriteLine($"{harry.Name} has {harry.Children.Count} children.");
            WriteLine($"{mary.Name} has {mary.Children.Count} children.");
            WriteLine($"{jill.Name} has {jill.Children.Count} children.");
            WriteLine(
                format: "{0}'s first child is named \"{1}\".",
                arg0: harry.Name,
                arg1: harry.Children[0].Name
            );

            WriteLine($"5! is {Person.Factorial(5)}");

            harry.Shout += Harry_Shout;
            for (int i = 1; i <= 4; i++)
            {
                Person.Poke(harry);
            }

            Person[] people =
            {
                new Person { Name = "Simon" },
                new Person { Name = "Jenny" },
                new Person { Name = "Adam "},
                new Person { Name = "Richard" }
            };
            WriteLine("Initial list of people:");
            foreach (var person in people)
            {
                WriteLine($"    {person.Name}");
            }
            /* WriteLine("Use Person's IComparable implementation to sort:");
            Array.Sort(people); */
            WriteLine($"Use PersonComparer's IComparer implementation to sort:");
            Array.Sort(people, new PersonComparer());
            foreach (var person in people)
            {
                WriteLine($"    {person.Name}");
            }
            
            var gt1 = new GenericThing<int>();
            gt1.Data = 42;
            WriteLine($"GenericThing with an integer: {gt1.Process(42)}");
            var gt2 = new GenericThing<string>();
            gt2.Data = "apple";
            WriteLine($"GenericThing with a string: {gt2.Process("apple")}");

            string number1 = "4";
            WriteLine($"{number1} squared is {Squarer.Square(number1)}.");
            byte number2 = 3;
            WriteLine($"{number2} squared is {Squarer.Square(number2)}.");

            var dv1 = new DisplacementVector(3, 5);
            var dv2 = new DisplacementVector(-2, 7);
            var dv3 = dv1 + dv2;

            WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");
            
            Employee john = new Employee
            {
                Name = "John Jones",
                DateOfBirth = new DateTime(1990, 7, 28)
            };
            john.WriteToConsole();
            john.EmployeeCode = "JJ001";
            john.HireDate = new DateTime(2014, 11, 23);
            WriteLine($"{john.Name} was hired on {john.HireDate:dd/MM/yy}");
            WriteLine(john.ToString());

            Employee aliceInEmployee = new Employee { Name = "Alice", EmployeeCode = "AA123" };
            Person aliceInPerson = aliceInEmployee;
            aliceInEmployee.WriteToConsole();
            aliceInPerson.WriteToConsole();
            WriteLine(aliceInEmployee.ToString());
            WriteLine(aliceInPerson.ToString());

            if (aliceInPerson is Employee)
            {
                WriteLine($"{nameof(aliceInPerson)} IS an Employee.");
                Employee explicitAlice = (Employee)aliceInPerson;
            }

            Employee aliceAsEmployee = aliceInPerson as Employee;
            if (aliceAsEmployee != null)
            {
                WriteLine($"{nameof(aliceInPerson)} AS an Employee.");
            }

            try
            {
                john.TimeTravel(new DateTime(1999, 12, 31));
                john.TimeTravel(new DateTime(1950, 12, 25));
            }
            catch (PersonException ex)
            {
                WriteLine(ex.Message);
            }

            string email1 = "pamela@test.com";
            string email2 = "ian&test.com";

            WriteLine($"{email1} is a valid e-mail address: {email1.IsValidEmail()}");
            WriteLine($"{email2} is a valid e-mail address: {email2.IsValidEmail()}");
        }
    }
}
