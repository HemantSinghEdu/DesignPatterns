using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Solid.OpenClosed
{
    public class CarFilter
    {
        public static IEnumerable<Car> FilterByColor(IEnumerable<Car> cars, Color color)
        {
            IEnumerable<Car> colorSpecificCars = cars.Where(car => car.Color == color).ToList();
            return colorSpecificCars;
        }

        public static IEnumerable<Car> FilterByType(IEnumerable<Car> cars, Type type)
        {
            IEnumerable<Car> typeSpecificCars = cars.Where(car => car.Type == type).ToList();
            return typeSpecificCars;
        }

        public static IEnumerable<Car> FilterByColorAndType(IEnumerable<Car> cars, Color color, Type type)
        {
            IEnumerable<Car> typeAndColorSpecificCars = cars.Where(car => car.Color == color && car.Type == type).ToList();
            return typeAndColorSpecificCars;
        }
    }
}
