using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Solid.OpenClosed
{
    class Program
    {
        static void Main(string[] args)
        {
            Car mercedes = new Car("Mercedes", Color.Black, Type.Sedan);
            Car audi = new Car("Audi", Color.Red, Type.SUV);
            Car lamborghini = new Car("Lamborghini", Color.Blue, Type.Race);
            Car chrysler = new Car("Chrysler", Color.Silver, Type.Sedan);
            Car bmw = new Car("BMW", Color.Black, Type.Convertible);
            Car mustang = new Car("Ford Mustang", Color.Red, Type.Race);
            Car porsche = new Car("Porche", Color.Silver, Type.Convertible);
            Car landRover = new Car("Jaguar Land Rover", Color.Red, Type.SUV);

            IEnumerable<Car> cars = new List<Car> { mercedes, audi, lamborghini, chrysler, bmw, mustang, porsche, landRover };


            //OLD WAY: Every new filter for cars is implemented by adding a new function to the CarFilter class
            IEnumerable<Car> redCars = CarFilter.FilterByColor(cars, Color.Red);
            IEnumerable<Car> suvCars = CarFilter.FilterByType(cars, Type.SUV);
            IEnumerable<Car> redSuvCars = CarFilter.FilterByColorAndType(cars, Color.Red, Type.SUV);
            Console.WriteLine(string.Format("Red cars: {0}", string.Join(",", redCars)));
            Console.WriteLine(string.Format("SUVs: {0}", string.Join(",", suvCars)));
            Console.WriteLine(string.Format("Red SUVs: {0}", string.Join(",", redSuvCars)));


            //BETTER WAY: 
            CarColorSpecificationc redColorSpec = new CarColorSpecificationc(Color.Red);
            CarTypeSpecification suvTypeSpec = new CarTypeSpecification(Type.SUV);
            AndSpecification<Car> redSuvSpec = new AndSpecification<Car>(redColorSpec, suvTypeSpec);
            IEnumerable<Car> redCarsNew = BetterCarFilter.Filter(cars, redColorSpec);
            IEnumerable<Car> suvCarsNew = BetterCarFilter.Filter(cars, suvTypeSpec);
            IEnumerable<Car> redSuvCarsNew = BetterCarFilter.Filter(cars, redSuvSpec);
            Console.WriteLine(string.Format("New Red cars: {0}", string.Join(",", redCarsNew)));
            Console.WriteLine(string.Format("New SUVs: {0}", string.Join(",", suvCarsNew)));
            Console.WriteLine(string.Format("New Red SUVs: {0}", string.Join(",", redSuvCarsNew)));

            Console.ReadKey();
        }
    }
}
