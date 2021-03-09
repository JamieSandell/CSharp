using Packt.Shared;
using static System.Console;
using System;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bob = new Person();
            WriteLine(bob.ToString());
            bob.Name = "Bob Smith";
            bob.DateOfBirth = new DateTime(1965, 12, 22);
            bob.FavouriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;            
            WriteLine(
                format: "{0}'s favourite wonder is {1}. Its integer is {2}",
                    arg0: bob.Name,
                    arg1: bob.FavouriteAncientWonder,
                    arg2: (int)bob.FavouriteAncientWonder
                );
            bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
            WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");
            bob.Children.Add(new Person {Name = "Alfred"});
            bob.Children.Add(new Person {Name = "Zoe"});
            WriteLine($"{bob.Name} has {bob.Children.Count} children.");
            foreach (Person child in bob.Children)
            {
                WriteLine($"{child.Name}");
            }

            var alice = new Person()
            {
                Name = "Alice Jones",
                DateOfBirth = new DateTime(1998, 3, 7)
            };
            WriteLine(
                format: "{0} was born on {1:dddd, d MMMM yyyy}",
                    arg0: alice.Name,
                    arg1: alice.DateOfBirth
            );
        }
    }
}
