using System;
using System.Collections.Generic;

namespace Strategy
{
    class Program
    {
        static void Main()
        {
            SortedList studentRecord = new SortedList();

            studentRecord.Add("Ronny");
            studentRecord.Add("Bobby");
            studentRecord.Add("Kate");
            studentRecord.Add("Mike");
            studentRecord.Add("Ricky");

            studentRecord.SetSortStrategy(new QuickSort());
            studentRecord.Sort();

            studentRecord.SetSortStrategy(new ShellSort());
            studentRecord.Sort();

            studentRecord.SetSortStrategy(new MergeSort());
            studentRecord.Sort();

            Console.ReadKey();
        }
    }

    abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }

    class QuickSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort(); // Default is Quicksort
            Console.WriteLine("QuickSorted list ");
        }
    }

    class ShellSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.ShellSort(); not-implemented
            Console.WriteLine("ShellSorted list ");
        }
    }

    class MergeSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.MergeSort(); not-implemented
            Console.WriteLine("MergeSorted list ");
        }
    }

    class SortedList
    {
        private List<string> _list = new List<string>();
        private SortStrategy _sortstrategy;

        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            this._sortstrategy = sortstrategy;
        }

        public void Add(string name)
        {
            _list.Add(name);
        }

        public void Sort()
        {
            _sortstrategy.Sort(_list);

            // Iterate over list and display results
            foreach (string name in _list)
            {
                Console.WriteLine(" " + name);
            }
            Console.WriteLine();
        }
    }
}