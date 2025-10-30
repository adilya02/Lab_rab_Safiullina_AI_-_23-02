using System;

namespace GeometryFigures
{
    public class Rectangle : Shape
    {
        private double _width;
        private double _height;

        public double Width
        {
            get => _width;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Ширина должна быть положительной");
                _width = value;
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Высота должна быть положительной");
                _height = value;
            }
        }

        public Rectangle(double width, double height) : base("Прямоугольник")
        {
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (Width + Height);
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Фигура: {Name}");
            Console.WriteLine($"Ширина: {Width:F2}, Высота: {Height:F2}");
            Console.WriteLine($"Площадь: {CalculateArea():F2}");
            Console.WriteLine($"Периметр: {CalculatePerimeter():F2}");
            Console.WriteLine(new string('-', 40));
        }

        public string GetDescription(string additionalInfo)
        {
            return $"Прямоугольник {Width:F2}×{Height:F2}. {additionalInfo}";
        }

        public double CalculateDiagonal()
        {
            return Math.Sqrt(Width * Width + Height * Height);
        }
    }
}