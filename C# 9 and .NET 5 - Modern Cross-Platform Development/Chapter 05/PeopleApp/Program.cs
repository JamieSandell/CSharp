﻿using Packt.Shared;
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

            BankAccount.InterestRate = 0.012M;

            var jonesAccount = new BankAccount();
            jonesAccount.AccountName = "Mrs. Jones";
            jonesAccount.Balance = 2400;
            WriteLine(format: "{0} earned {1:C} interest.",
                arg0: jonesAccount.AccountName,
                arg1: jonesAccount.Balance * BankAccount.InterestRate);

            var gerrierAccount = new BankAccount();
            gerrierAccount.AccountName = "Ms. Gerrier";
            gerrierAccount.Balance = 98;
            WriteLine(format: "{0} earned {1:C} interest.",
                arg0: gerrierAccount.AccountName,
                arg1: gerrierAccount.Balance * BankAccount.InterestRate);

            WriteLine($"{bob.Name} is a {Person.Species}");
            WriteLine($"{bob.Name} was born on {bob.HomePlanet}");

            var blankPerson = new Person();
            WriteLine(format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
                arg0: blankPerson.Name,
                arg1: blankPerson.HomePlanet,
                arg2: blankPerson.Instantiated);

            var gunny = new Person("Gunny", "Mars");
            WriteLine(format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
                arg0: gunny.Name,
                arg1: gunny.HomePlanet,
                arg2: gunny.Instantiated);

            bob.WriteToConsole();
            WriteLine(bob.GetOrigin());

            (string, int) fruit = bob.GetFruit();
            WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

            var fruitNamed = bob.GetNamedFruit();
            WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");

            var thing1 = ("Neville", 4);
            WriteLine($"{thing1.Item1} has {thing1.Item2} children.");

            var thing2 = (bob.Name, bob.Children.Count); // C# 7.1 onwards can infer the names, in this instance .Name and .Count instead of .Item1 and .Item2
            WriteLine($"{thing2.Name} has {thing2.Count} children.");

            (string fruitName, int fruitNumber) = bob.GetFruit(); // deconstructing tuples
            WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");

            WriteLine(bob.SayHello());
            WriteLine(bob.SayHello("Emily"));

            WriteLine(bob.OptionalParameters());
            WriteLine(bob.OptionalParameters("Jump!", 98.5));
            WriteLine(bob.OptionalParameters(number: 52.7, command: "Hide!"));
            WriteLine(bob.OptionalParameters("Poke!", active: false));

            int a = 10;
            int b = 20;
            int c = 30;
            WriteLine($"Before: a = {a}, b = {b}, c = {c}");
            bob.PassingParameters(a, ref b, out c);
            WriteLine($"After: a = {a}, b = {b}, c = {c}");

            int d = 10;
            int e = 20;
            WriteLine($"Before: d = {d}, e = {e}, f doesn't exist yet");
            // simplified C# 7.0 syntax for the out parameter
            bob.PassingParameters(d, ref e, out int f);
            WriteLine($"After: d = {d}, e = {e}, f = {f}");

            var sam = new Person
            {
                Name = "Sam",
                DateOfBirth = new DateTime(1972, 1, 27)
            };
            WriteLine(sam.Origin);
            WriteLine(sam.Greeting);
            WriteLine(sam.Age);

            sam.FavouriteIceCream = "Chocolate Fudge";
            WriteLine($"Sam's favourite ice-cream flavour is {sam.FavouriteIceCream}");
            sam.FavouritePrimaryColour = "Red";
            WriteLine($"Sam's favourite primary colour is {sam.FavouritePrimaryColour}");

            sam.Children.Add(new Person {Name = "Charlie"});
            sam.Children.Add(new Person {Name = "Ella"});
            WriteLine($"Sam's first child is {sam.Children[0].Name}");
            WriteLine($"Sam's second child is {sam.Children[1].Name}");
            WriteLine($"Sam's first child is {sam[0].Name}");
            WriteLine($"Sam's second child is {sam[1].Name}");

            object[] passengers = {
                new FirstClassPassenger {AirMiles = 1_419},
                new FirstClassPassenger {AirMiles = 16_562},
                new BusinessClassPassenger(),
                new CoachClassPassenger {CarryOnKG = 25.7},
                new CoachClassPassenger {CarryOnKG = 0}
            };

            foreach(object passenger in passengers)
            {
                decimal flightCost = passenger switch
                {
                    /* C# 8 syntax
                    FirstClassPassenger p when p.AirMiles > 35000 => 1500M,
                    FirstClassPassenger p when p.AirMiles > 15000 => 1750M,
                    FirstClassPassenger _                         => 2000M,
                    BusinessClassPassenger _                      => 1000M,
                    CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
                    CoachClassPassenger _                         => 650M,
                    _                                             => 800M */
                    // C# 9 syntax
                    FirstClassPassenger p => p.AirMiles switch
                    {
                        > 35000 => 1500M,
                        > 15000 => 1750M,
                        _       => 2000M
                    },
                    BusinessClassPassenger                        => 1000M,
                    CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
                    CoachClassPassenger                           => 650M,
                    _                                             => 800M
                };
                WriteLine($"Flight costs {flightCost:C} for {passenger}");
            }

            var Jeff = new ImmutablePerson
            {
                FirstName = "Jeff",
                Surname = "Winger"
            };

            var car = new ImmutableVehicle
            {
                Brand = "Mazda MX-5 RF",
                Color = "Soul Red Crystal Metallic",
                Wheels = 4
            };
            var repaintedCar = car with { Color = "Polymetal Grey Metallic" };
            WriteLine($"Original colour was {car.Color}, new color is {repaintedCar.Color}");

            var oscar = new ImmutableAnimal("Oscar", "Labrador");
            var (who, what) = oscar; // calls Deconstruct method
            WriteLine($"{who} is {what}");
        }
    }
}
