using System;

namespace GeometryFigures
{
    public class Romb : Shape
    {
        private double _side;
        private double _diagonal1;
        private double _diagonal2;

        public double Side
        {
            get => _side;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Сторона ромба должна быть положительной");
                _side = value;
            }
        }

        public double Diagonal1
        {
            get => _diagonal1;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Диагональ должна быть положительной");
                _diagonal1 = value;
            }
        }

        public double Diagonal2
        {
            get => _diagonal2;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Диагональ должна быть положительной");
                _diagonal2 = value;
            }
        }

        public Romb(double side, double diagonal1, double diagonal2) : base("Ромб")
        {
            Side = side;
            Diagonal1 = diagonal1;
            Diagonal2 = diagonal2;

            if (!IsValidRhombus())
                throw new ArgumentException("Некорректные параметры ромба: диагонали не соответствуют стороне");
        }

        public Romb(double side) : base("Ромб (квадрат)")
        {
            Side = side;
            // Для квадрата диагонали вычисляются автоматически
            Diagonal1 = side * Math.Sqrt(2);
            Diagonal2 = side * Math.Sqrt(2);
        }

        public override double CalculateArea()
        {
            return (Diagonal1 * Diagonal2) / 2;
        }

        public override double CalculatePerimeter()
        {
            return 4 * Side;
        }

        public override string GetDescription()
        {
            return $"Ромб со стороной {Side:F2} и диагоналями {Diagonal1:F2} и {Diagonal2:F2}";
        }

        private bool IsValidRhombus()
        {
            double halfD1 = Diagonal1 / 2;
            double halfD2 = Diagonal2 / 2;
            double expectedSide = Math.Sqrt(halfD1 * halfD1 + halfD2 * halfD2);
            
            return Math.Abs(Side - expectedSide) < 0.001; // Допустимая погрешность
        }

        public double CalculateAcuteAngle()
        {
            return 2 * Math.Atan2(Diagonal2, Diagonal1) * (180 / Math.PI);
        }
    }
}