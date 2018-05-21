using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            //Flyweight Factory
            ShapeFactory shapeFactory = new ShapeFactory();

            IShape shapeOne = shapeFactory.GetShape("Triangle");
            shapeOne.draw();

            IShape shapeTwo = shapeFactory.GetShape("Triangle");
            shapeTwo.draw();

            IShape shapeThree = shapeFactory.GetShape("Triangle");
            shapeThree.draw();

            IShape shapeFour = shapeFactory.GetShape("Square");
            shapeFour.draw();

            IShape shapeFive = shapeFactory.GetShape("Square");
            shapeFive.draw();

            IShape shapeSix = shapeFactory.GetShape("Square");
            shapeSix.draw();

            Console.WriteLine($"Total Shape Objects {shapeFactory.ShapesCount}");
            Console.Read();
        }
    }

    interface IShape
    {
        void draw();
    }

    class Triangle : IShape
    {
        public void draw()
        {
            Console.WriteLine("Drawing Triangle...");
        }
    }

    class Square : IShape
    {
        public void draw()
        {            
            Console.WriteLine("Drawing Square...");
        }
    }

    class ShapeFactory
    {
        Dictionary<string, IShape> shapes = new Dictionary<string, IShape>();

        public int ShapesCount {
            get {
                return shapes.Count;
            }
        }

        public IShape GetShape(string shapeName)
        {
            IShape shape = null;

            if (shapes.ContainsKey(shapeName))
            {
                shape = shapes[shapeName];
            }
            else
            {
                switch (shapeName)
                {
                    case "Triangle" :
                        shape = new Triangle();
                        shapes.Add("Triangle", shape);
                        break;
                    case "Square":
                        shape = new Square();
                        shapes.Add("Square", shape);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            return shape;
        }
    }

}
