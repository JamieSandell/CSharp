namespace Packt.Shared
{
    public partial class Person
    {
        public Person this[int index]
        {
            get
            {
                return Children[index];
            }
            set
            {
                Children[index] = value;
            }
        }
        // property defined using C# 1 - 5 syntax
        public string Origin
        {
            get
            {
                return $"{Name} was born on {HomePlanet}";
            }
        }

        // two properties defined using C# 6+ Lambda expression syntax
        public string Greeting => $"{Name} says 'Hello!'";
        public int Age => System.DateTime.Today.Year - DateOfBirth.Year;

        public string FavouriteIceCream {get; set;}
        private string favouritePrimaryColour;
        public string FavouritePrimaryColour
        {
            get
            {
                return favouritePrimaryColour;
            }
            set
            {
                switch (value.ToLower())
                {
                    case "red":
                    case "green":
                    case "blue":
                        favouritePrimaryColour = value;
                        break;
                    default:
                        throw new System.ArgumentException($"{value} is not a primary colour. " + "Choose from: red, green, blue.");
                }
            }
        }
    }
}