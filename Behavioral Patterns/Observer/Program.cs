using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            ICelebrity bradPitt = new MovieStar("Brad Pitt", "New Movie");
            IFan firstFan = new Fan();

            bradPitt.AddFollower(firstFan);
            bradPitt.Tweet = "My new movie trailer launched.";

            Console.Read();
        }
    }

    public interface ICelebrity
    {
        string FullName { get; }
        string Tweet { get; set; }
        void Notify(string tweet);
        void AddFollower(IFan fan);
        void RemoveFollower(IFan fan);
    }

    public class MovieStar : ICelebrity
    {
        private readonly List<IFan> _fans = new List<IFan>();       
        private string _tweet;                                      

        public MovieStar(string fullName , string tweet)
        {
            FullName = fullName;
            _tweet = tweet;
        }

        public string FullName { get; set; }

        public string Tweet
        {
            get { return _tweet; }

            set
            {
                _tweet = value;
                Notify(value);
            }
        }

        public void AddFollower(IFan fan)
        {
            _fans.Add(fan);
        }
    
        public void RemoveFollower(IFan fan)
        {
            _fans.Remove(fan);
        }

        public void Notify(string tweet)
        {
            foreach (var fan in _fans)
            {
                fan.Update(this);
            }
        }
    }

    public interface IFan
    {
        void Update(ICelebrity celebrity);
    }

    public class Fan : IFan
    {
        public void Update(ICelebrity celebrity)
        {
            Console.WriteLine($"Fan notified. Tweet of {celebrity.FullName}: " +
                $"{celebrity.Tweet}");
        }
    }
}
