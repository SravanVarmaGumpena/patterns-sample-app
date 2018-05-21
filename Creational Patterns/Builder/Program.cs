using System;
using System.Collections.Generic;

namespace Builder
{
    static class Program
    {
        static void Main()
        {
            CarBuilder basicCarBuilder = new BasicCarBuilder();
            CarBuilder superCarBuilder = new SuperCarBuilder();

            List<CarBuilder> builders = new List<CarBuilder>()
            {
                basicCarBuilder,
                superCarBuilder
            };

            CarDirector director = new CarDirector();

            foreach (CarBuilder builder in builders)
            {
                Car car = director.Build(builder);
                Console.WriteLine($"Car Built By: {builder.GetType().Name}"); 
                Console.WriteLine($"Top Speed: {car.TopSpeed}");
                Console.WriteLine($"Horse Power: {car.HorsePower}");
                Console.WriteLine();
            }

            Console.Read();
        }
    }

    public class Car
    {
        public int TopSpeed { get; set; }
        public int HorsePower { get; set; }
    }

    public abstract class CarBuilder
    {
        public abstract void SetTopSpeed();
        public abstract void SetHorsePower();

        protected readonly Car Car = new Car();

        public virtual Car GetCar()
        {
            return Car;
        }
    }

    public class BasicCarBuilder : CarBuilder
    {
        public override void SetTopSpeed()
        {
            Car.TopSpeed = 70;
        }

        public override void SetHorsePower()
        {
            Car.HorsePower = 120;
        }
    }

    public class SuperCarBuilder : CarBuilder
    {
        public override void SetTopSpeed()
        {
            Car.TopSpeed = 700;
        }

        public override void SetHorsePower()
        {
            Car.HorsePower = 1200;
        }
    }

    public class CarDirector
    {
        public Car Build(CarBuilder builder)
        {
            builder.SetTopSpeed();
            builder.SetHorsePower();
            return builder.GetCar();
        }
    }
}
