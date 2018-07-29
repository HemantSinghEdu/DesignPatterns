using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Solid.OpenClosed
{
    public enum Color { Red, Blue, Green, Black, Silver }
    public enum Type { Sedan, Hatchback, SUV, Convertible, Race }

    public class Car
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Type Type { get; set; }

        public Car(string name, Color color, Type type)
        {
            Name = name;
            Color = color;
            Type = type;
        }
    }

}
