using System;

namespace GeometryFigures
{
    public class Ellips : Shape
    {
        private double _semiMajorAxis;
        private double _semiMinorAxis;

        public double SemiMajorAxis
        {
            get => _semiMajorAxis;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Большая полуось должна быть положительной");
                _semiMajorAxis = value;
            }
        }

        public double SemiMinorAxis
        {
            get => _semiMinorAxis;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Малая полуось должна быть положительной");
                _semiMinorAxis = value;
            }
        }

        public Ellips(double semiMajorAxis, double semiMinorAxis) : base("Эллипс")
        {
            if (semiMajorAxis < semiMinorAxis)
                throw new ArgumentException("Большая полуось должна быть больше или равна малой полуоси");

            SemiMajorAxis = semiMajorAxis;
            SemiMinorAxis = semiMinorAxis;
        }

        public override double CalculateArea()
        {
            return Math.PI * SemiMajorAxis * SemiMinorAxis;
        }

        public override double CalculatePerimeter()
        {
            double h = Math.Pow((SemiMajorAxis - SemiMinorAxis) / (SemiMajorAxis + SemiMinorAxis), 2);
            return Math.PI * (SemiMajorAxis + SemiMinorAxis) * (1 + (3 * h) / (10 + Math.Sqrt(4 - 3 * h)));
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Фигура: {Name}");
            Console.WriteLine($"Большая полуось: {SemiMajorAxis:F2}, Малая полуось: {SemiMinorAxis:F2}");
            Console.WriteLine($"Площадь: {CalculateArea():F4}"); // Более точный вывод для эллипса
            Console.WriteLine($"Периметр (приближенно): {CalculatePerimeter():F4}");
            Console.WriteLine(new string('-', 40));
        }

        public override string GetDescription()
        {
            return $"Эллипс с полуосями {SemiMajorAxis:F2} и {SemiMinorAxis:F2}";
        }

        public double CalculateEccentricity()
        {
            return Math.Sqrt(1 - Math.Pow(SemiMinorAxis / SemiMajorAxis, 2));
        }
    }
}