using Patterns.Solid.OpenClosed.Simple.BetterWay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Solid.OpenClosed.Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //OLD WAY: Every new shape will need a new function to be added to AreaCalculator
            OldWay.Rectangle rectangle = new OldWay.Rectangle(5, 6);
            OldWay.Square square = new OldWay.Square(5);
            OldWay.Circle circle = new OldWay.Circle(2);
            object[] array = new object[] { rectangle, square, circle };
            OldWay.AreaCalculator.PrintArea(array);

            //BETTER WAY: No difference here, but the way AreaCalculator is defined is different. No more modifications in that class
            //needed whenever a new shape is added
            BetterWay.Rectangle bRectangle = new BetterWay.Rectangle(5, 6);
            BetterWay.Square bSquare = new BetterWay.Square(5);
            BetterWay.Circle bCircle = new BetterWay.Circle(2);
            IShape[] bArray = new IShape[] { bRectangle, bSquare, bCircle };
            BetterWay.AreaCalculator.PrintArea(bArray);

            Console.ReadKey();
        }
    }
}
