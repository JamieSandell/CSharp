namespace Packt.Shared
{
    public class ImmutablePerson
    {
        public string FirstName { get; init; }
        public string Surname { get; init;}
    }

    public record ImmutableVehicle
    {
        public int Wheels { get; init;}
        public string Color { get; init; }
        public string Brand { get; init; }
    }

    // simpler way to define a record that has public init-only properties, also creates a consturctor and destructor for you
    public record ImmutableAnimal(string Name, string Species);
}