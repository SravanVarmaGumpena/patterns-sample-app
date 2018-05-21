using System;
using System.Collections.Generic;

namespace Mediator
{
    class Program
    {
        static void Main()
        {
            // Create chatroom
            Chatroom chatroom = new Chatroom();

            Participant Eddie = new Actor("Eddie");
            Participant Jennifer = new Actor("Jennifer");
            Participant Bruce = new Actor("Bruce");
            Participant Tom = new Actor("Tom");
            Participant Tony = new NonActor("Tony");

            // Create participants and register them
            chatroom.Register(Eddie);
            chatroom.Register(Jennifer);
            chatroom.Register(Bruce);
            chatroom.Register(Tom);
            chatroom.Register(Tony);

            // Chatting participants
            Tony.Send("Tom", "Hey Tom! I got a mission for you.");
            Jennifer.Send("Bruce", "Teach me to act and I'll" +
                " teach you to dance");
            Bruce.Send("Eddie", "How come you don't do standup anymore?");

            Jennifer.Send("Tom", "Do you like math?");
            Tom.Send("Tony", "Teach me to sing.");

            // Wait for user
            Console.ReadKey();
        }
    }

    abstract class AbstractChatroom
    {
        public abstract void Register(Participant participant);
        public abstract void Send(string from, string to, string message);
    }

    class Chatroom : AbstractChatroom
    {
        private Dictionary<string, Participant> _participants =
          new Dictionary<string, Participant>();

        public override void Register(Participant participant)
        {
            if (!_participants.ContainsValue(participant))
            {
                _participants[participant.Name] = participant;
            }

            participant.Chatroom = this;
        }

        public override void Send(string from, string to, string message)
        {
            Participant participant = _participants[to];

            if (participant != null)
            {
                participant.Receive(from, message);
            }
        }
    }

    class Participant
    {
        private Chatroom _chatroom;
        private string _name;

        public Participant(string name)
        {
            this._name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        // Gets chatroom
        public Chatroom Chatroom
        {
            set { _chatroom = value; }
            get { return _chatroom; }
        }

        // Sends message to given participant
        public void Send(string to, string message)
        {
            _chatroom.Send(_name, to, message);
        }

        // Receives message from given participant
        public virtual void Receive(string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'", from, Name, message);
        }
    }

    class Actor : Participant
    {
        public Actor(string name)
          : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.Write("To an Actor: ");
            base.Receive(from, message);
        }
    }

    class NonActor : Participant
    {
        public NonActor(string name)
          : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.Write("To a non-Actor: ");
            base.Receive(from, message);
        }
    }
}
