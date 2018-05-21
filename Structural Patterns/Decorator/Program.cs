using System;

namespace Decorator
{
    class Program
    {
        static void Main()
        {
            Car compactCar = new CompactCar();
            Console.WriteLine($"Description: {compactCar.GetDescription()}");
            Console.WriteLine($"Description: {compactCar.GetCarPrice()}");
            Console.WriteLine();

            Car fullSizeCar = new FullSizeCar();
            Console.WriteLine($"Description: {fullSizeCar.GetDescription()}");
            Console.WriteLine($"Description: {fullSizeCar.GetCarPrice()}");
            Console.WriteLine();

            Car otherCompactCarWithDecorators = new CompactCar();
            otherCompactCarWithDecorators = new LeatherSeatDecorator(otherCompactCarWithDecorators);
            otherCompactCarWithDecorators = new NavigationDecorator(otherCompactCarWithDecorators);
            Console.WriteLine($"Description: {otherCompactCarWithDecorators.GetDescription()}");
            Console.WriteLine($"Description: {otherCompactCarWithDecorators.GetCarPrice()}");

            Console.Read();
        }
    }

    public abstract class Car
    {
        public string Description { get; set; }
        public abstract int GetCarPrice();
        public abstract string GetDescription();
    }

    public class CarDecorator : Car
    {
        protected Car Car;

        public CarDecorator(Car car)
        {
            Car = car;
        }

        public override int GetCarPrice()
        {
            return Car.GetCarPrice();
        }

        public override string GetDescription()
        {
            return Car.GetDescription();
        }
    }

    public class CompactCar : Car
    {
        public CompactCar()
        {
            Description = "Compact Car";
        }

        public override int GetCarPrice()
        {
            return 500000;
        }

        public override string GetDescription()
        {
            return Description;
        }
    }

    public class FullSizeCar : Car
    {
        public FullSizeCar()
        {
            Description = "FullSize Car";
        }

        public override int GetCarPrice()
        {
            return 1000000;
        }

        public override string GetDescription()
        {
            return Description;
        }
    }

    public class LeatherSeatDecorator : CarDecorator
    {
        public LeatherSeatDecorator(Car car) : base(car)
        {
            Description = "Leather Seat";
        }

        public override int GetCarPrice()
        {
            return Car.GetCarPrice() + 10000;
        }

        public override string GetDescription()
        {
            return $"{Car.GetDescription()}, {Description}";
        }
    }

    public class NavigationDecorator : CarDecorator
    {
        public NavigationDecorator(Car car) : base(car)
        {
            Description = "Navigation";
        }

        public override int GetCarPrice()
        {
            return Car.GetCarPrice() + 40000;
        }

        public override string GetDescription()
        {
            return $"{Car.GetDescription()}, {Description}";
        }
    }
}
