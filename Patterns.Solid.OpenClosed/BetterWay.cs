using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Solid.OpenClosed
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public class CarColorSpecificationc : ISpecification<Car>
    {
        private Color color;

        public CarColorSpecificationc(Color color)
        {
            this.color = color;
        }

        public bool IsSatisfied(Car car)
        {
            return car.Color == color;
        }
    }

    public class CarTypeSpecification : ISpecification<Car>
    {
        private Type type;

        public CarTypeSpecification(Type type)
        {
            this.type = type;
        }

        public bool IsSatisfied(Car car)
        {
            return car.Type == type;
        }
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> first, second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first;     //??throw new ArgumentNullException("first");
            this.second = second;   //??throw new ArgumentNullException("second");
        }

        public bool IsSatisfied(T t)
        {
            return first.IsSatisfied(t) && second.IsSatisfied(t);
        }
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class BetterCarFilter : IFilter<Car>
    {

        public static IEnumerable<Car> Filter(IEnumerable<Car> cars, ISpecification<Car> spec)
        {
            List<Car> filteredCars = new List<Car>();
            foreach (var car in cars)
            {
                if (spec.IsSatisfied(car))
                {
                    filteredCars.Add(car);
                }
            }
            return filteredCars;
        }
    }
}
