using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Solid.OpenClosed.Simple.BetterWay
{
    public interface IShape
    {
        string Name { get; set; }
        float Area();
    }
    public class Rectangle : IShape
    {
        private float length;
        private float breadth;
        public string Name { get; set; }

        public Rectangle(float length, float breadth)
        {
            this.length = length;
            this.breadth = breadth;
            Name = "Rectangle";
        }

        public float Area()
        {
            return length * breadth;
        }
    }

    public class Square : IShape
    {
        private float side;
        public string Name { get; set; }
        public Square(float side)
        {
            this.side = side;
            Name = "Square";
        }
        public float Area()
        {
            return side * side;
        }
    }

    public class Circle : IShape
    {
        private float radius;
        public string Name { get; set; }
        public Circle(float radius)
        {
            this.radius = radius;
            Name = "Circle";
        }
        public float Area()
        {
            return 3.14f * radius * radius;
        }
    }

    public class AreaCalculator
    {
        public static void PrintArea(IShape[] shapes)
        {
            foreach (var shape in shapes)
            {
                float area = shape.Area();
                string shapeName = shape.Name;
                Console.WriteLine(string.Format("Area of {0} is: {1}", shapeName, area));
            }
        }
    }
}
