using System;
using System.Collections.Generic;
using System.Linq;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            INewspaper nyp = new NYPaper();
            INewspaper lap = new LAPaper();

            IIterator nypIterator = nyp.CreateIterator();
            IIterator lapIterator = lap.CreateIterator();

            Console.WriteLine("--------   NYPaper");
            PrintReporters(nypIterator);

            Console.WriteLine("--------   LAPaper");
            PrintReporters(lapIterator);

            Console.ReadLine();
        }

        static void PrintReporters(IIterator iterator)
        {
            iterator.First();
            while (!iterator.IsDone())
            {
                Console.WriteLine(iterator.Next());
            }
        }
    }

    // Iterator
    public interface IIterator
    {
        void First();           //  Sets current element to the first element
        string Next();          //  Advances current to next element
        bool IsDone();          //  Check if end of collection
        string CurrentItem();   //  returns the current element
    }

    public class LAPaperIterator : IIterator
    {
        private string[] _reporters;
        private int _current;

        public LAPaperIterator(string[] _reporters)
        {
            this._reporters = _reporters;
            _current = 0;
        }
        public string CurrentItem()
        {
            return _reporters[_current];
        }

        public void First()
        {
            _current = 0;
        }

        public bool IsDone()
        {
            return _current >= _reporters.Length;
        }

        public string Next()
        {
            return _reporters[_current++];
        }
    }

    public class NYPaperIterator : IIterator
    {
        private List<string> _reporters;
        private int _current;

        public NYPaperIterator(List<string> _reporters)
        {
            this._reporters = _reporters;
            _current = 0;
        }

        public string CurrentItem()
        {
            return _reporters.ElementAt(_current);
        }

        public void First()
        {
            _current = 0;
        }

        public bool IsDone()
        {
            return _current >= _reporters.Count;
        }

        public string Next()
        {
            return _reporters.ElementAt(_current++);
        }
    }

    // Aggregate
    public interface INewspaper
    {
        IIterator CreateIterator();
    }

    // ConcreteAggregate
    public class LAPaper : INewspaper
    {
        private string[] _reporters;
        public LAPaper()
        {
            _reporters = new [] {
                                     "Ronald Smith - LA",
                                     "Danny Glover - LA",
                                     "Yolanda Adams - LA",
                                     "Jerry Straight - LA",
                                     "Rhonda Lime - LA",
                                };
        }

        public IIterator CreateIterator()
        {
            return new LAPaperIterator(_reporters);
        }
    }

    // ConcreteAggregate
    public class NYPaper : INewspaper
    {
        private List<string> _reporters;
        public NYPaper()
        {
            _reporters = new List<string>
                        {
                             "John Mesh - NY",
                             "Susanna Lee - NY",
                             "Paul Randy - NY",
                             "Kim Fields - NY",
                             "Sky Taylor - NY"
                        };
        }

        public IIterator CreateIterator()
        {
            return new NYPaperIterator(_reporters);
        }
    }
}
