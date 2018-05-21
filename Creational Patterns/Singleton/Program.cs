using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton instanceOne = Singleton.Instance;
            Singleton instanceTwo = Singleton.Instance;
            Console.WriteLine(ReferenceEquals(instanceOne, instanceTwo));

            Console.Read();
        }
    }

    public class Singleton
    {
        private static readonly Singleton mInstance = new Singleton();

        public static Singleton Instance
        {
            get
            {
                return mInstance;
            }
        }
    }
}
