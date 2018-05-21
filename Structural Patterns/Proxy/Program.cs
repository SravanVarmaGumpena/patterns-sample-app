using System;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            MathProxy proxy = new MathProxy();

            Console.WriteLine($"10 + 5 = {proxy.Add(10,5)}");
            Console.WriteLine($"10 - 5 = {proxy.Subtract(10,5)}");
            Console.WriteLine($"10 X 5 = {proxy.Multiply(10,5)}");
            Console.WriteLine($"10 ÷ 5 = {proxy.Divide(10,5)}");

            Console.Read();
        }
    }

    interface IMath
    {
        double Add(double x, double y);
        double Subtract(double x, double y);
        double Multiply(double x, double y);
        double Divide(double x, double y);
    }

    class Math : IMath
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Subtract(double x, double y)
        {
            return x - y;            
        }

        public double Multiply(double x, double y)
        {
            return x * y;
        }

        public double Divide(double x, double y)
        {
            return x / y;
        }
    }

    class MathProxy : IMath
    {
        private Math math = new Math();

        public double Add(double x, double y)
        {
            return math.Add(x, y);
        }

        public double Subtract(double x, double y)
        {
            return math.Subtract(x, y);
        }

        public double Multiply(double x, double y)
        {
            return math.Multiply(x, y);
        }

        public double Divide(double x, double y)
        {
            return math.Divide(x, y);
        }
    }
}
