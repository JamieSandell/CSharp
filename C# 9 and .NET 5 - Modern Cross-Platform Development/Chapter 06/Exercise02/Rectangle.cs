using static System.Math;

namespace Exercise02
{
    public class Rectangle : Shape
    {
        public override double Area
        {
            get => Height * Width;
            set => Height = Width = Sqrt(value);
        }

        public Rectangle(double height, double width) : base(height, width) {}
    }
}