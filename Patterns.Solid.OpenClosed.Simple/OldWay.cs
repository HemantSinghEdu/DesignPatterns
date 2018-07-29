using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Solid.OpenClosed.Simple.OldWay
{
    public class Rectangle
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

    public class Square
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

    public class Circle
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
        public static void PrintArea(object[] shapes)
        {
            foreach (var shape in shapes)
            {
                float area = 0;
                string shapeName = string.Empty;

                if (shape is Rectangle)
                {
                    var rectangle = shape as Rectangle;
                    shapeName = rectangle.Name;
                    area = rectangle.Area();
                }
                else if (shape is Square)
                {
                    var square = shape as Square;
                    shapeName = square.Name;
                    area = square.Area();
                }
                else if (shape is Circle)
                {
                    var circle = shape as Circle;
                    shapeName = circle.Name;
                    area = circle.Area();
                }

                Console.WriteLine(string.Format("Area of {0} is: {1}", shapeName, area));
            }
        }
    }
}
