using System;

namespace Bridge
{
    static class Program
    {
        static void Main()
        {
            IMessageSender text = new TextMessageSender();
            IMessageSender web = new WebServiceMessageSender();

            Message message = new SystemMessage();
            message.Subject = "A Message";
            message.Body = "Hi there, please accept this message!";

            message.MessageSender = text;
            message.Send();

            Console.WriteLine();

            message.MessageSender = web;
            message.Send();

            Console.Read();
        }
    }

    public abstract class Message
    {
        public IMessageSender MessageSender { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }

        public abstract void Send();

    }

    public class SystemMessage : Message
    {
        public override void Send()
        {
            MessageSender.SendMessage(Subject, Body);
        }
    }

    public interface IMessageSender
    {
        void SendMessage(string subject, string body);
    }

    public class TextMessageSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            Console.WriteLine($"Message Type: Text");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Body: {body}");
        }
    }

    public class WebServiceMessageSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            Console.WriteLine($"Message Type: Web");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Body: {body}");
        }
    }
}
