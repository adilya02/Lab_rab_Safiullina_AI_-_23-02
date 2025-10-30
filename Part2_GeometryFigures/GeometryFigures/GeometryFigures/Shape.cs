using System;

namespace GeometryFigures
{
    public abstract class Shape : IShape
    {
        public string Name { get; protected set; }

        public Shape(string name)
        {
            Name = name;
            Console.WriteLine($"Создана фигура: {name}");
        }

        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Фигура: {Name}");
            Console.WriteLine($"Площадь: {CalculateArea():F2}");
            Console.WriteLine($"Периметр: {CalculatePerimeter():F2}");
            Console.WriteLine(new string('-', 40));
        }

        public virtual string GetDescription()
        {
            return "Это геометрическая фигура";
        }
    }
}