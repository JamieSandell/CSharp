using static System.Math;

namespace Exercise02
{
    public class Square : Shape
    {
        public override double Area
        {
            get => Height * Width;
            set => Height = Width = Sqrt(value);
        }

        public Square(double side) : base(side, side) {}
    }
}