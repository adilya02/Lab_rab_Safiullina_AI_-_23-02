using System;

namespace GeometryFigures
{
    /// <summary>
    /// Интерфейс для геометрических фигур
    /// </summary>
    public interface IShape
    {
       
        double CalculateArea();

        double CalculatePerimeter();
        
        void PrintInfo();
    }
}