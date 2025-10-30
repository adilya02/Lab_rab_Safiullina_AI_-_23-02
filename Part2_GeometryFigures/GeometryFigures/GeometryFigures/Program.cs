using System;
using System.Collections.Generic;

namespace GeometryFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Демонстрация иерархии геометрических фигур (Вариант 8)");
            Console.WriteLine("=====================================================\n");

            try
            {
                List<Shape> shapes = new List<Shape>();

                Console.WriteLine("1. Создание фигур и вызов конструкторов:");
                Console.WriteLine("----------------------------------------");

                Rectangle rectangle = new Rectangle(5.0, 3.0);
                shapes.Add(rectangle);
                Console.WriteLine($"Создан {rectangle.GetDescription()}");

                Romb romb = new Romb(5.0, 6.0, 8.0);
                shapes.Add(romb);
                Console.WriteLine($"Создан {romb.GetDescription()}");

                Romb squareRomb = new Romb(5.0);
                shapes.Add(squareRomb);
                Console.WriteLine($"Создан {squareRomb.GetDescription()}");

                Ellips ellips = new Ellips(6.0, 4.0);
                shapes.Add(ellips);
                Console.WriteLine($"Создан {ellips.GetDescription()}");

                Console.WriteLine("\n2. Демонстрация работы всех методов:");
                Console.WriteLine("-------------------------------------");

                foreach (var shape in shapes)
                {
                    shape.PrintInfo();
                }

                Console.WriteLine("3. Демонстрация перегруженных методов:");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine(rectangle.GetDescription("Это прямоугольник с прямыми углами."));

                Console.WriteLine("\n4. Демонстрация специфических методов:");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"Диагональ прямоугольника: {rectangle.CalculateDiagonal():F2}");
                Console.WriteLine($"Острый угол ромба: {romb.CalculateAcuteAngle():F1}°");
                Console.WriteLine($"Эксцентриситет эллипса: {ellips.CalculateEccentricity():F4}");

                Console.WriteLine("\n5. Демонстрация работы с интерфейсом:");
                Console.WriteLine("-------------------------------------");
                DemonstrateInterfaceUsage(shapes);

                Console.WriteLine("\n6. Обработка исключений:");
                Console.WriteLine("------------------------");
                DemonstrateExceptionHandling();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void DemonstrateInterfaceUsage(List<Shape> shapes)
        {
            foreach (IShape shape in shapes)
            {
                Console.WriteLine($"Через интерфейс: {shape.GetType().Name}");
                Console.WriteLine($"  Площадь: {shape.CalculateArea():F2}");
                Console.WriteLine($"  Периметр: {shape.CalculatePerimeter():F2}");
            }
        }

        static void DemonstrateExceptionHandling()
        {
            try
            {
                Rectangle invalidRectangle = new Rectangle(-5.0, 3.0);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Перехвачено исключение: {ex.Message}");
            }

            try
            {
                Ellips invalidEllips = new Ellips(3.0, 5.0);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Перехвачено исключение: {ex.Message}");
            }

            try
            {
                Romb invalidRhomb = new Romb(4.0, 2.0, 2.0);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Перехвачено исключение: {ex.Message}");
            }
        }
    }
}