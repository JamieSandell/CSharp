namespace Exercise02
{
    public class Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public virtual double Area { get; set; }

        public Shape(double height, double width)
        {
            Height = height;
            Width = width;
        }
    }
}