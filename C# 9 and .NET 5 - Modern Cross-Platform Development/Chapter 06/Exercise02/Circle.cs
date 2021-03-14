using static System.Math;

namespace Exercise02
{
    public class Circle : Shape
    {
        public override double Area
        {
            get => PI * Pow(Height / 2, 2);
            set => Height = Width = Sqrt(value / PI) * 2;
        }

        public Circle(double radius) : base(radius * 2, radius * 2) {}
    }
}