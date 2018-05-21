using System;

namespace Chain_of_Responsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Approver director = new Director();
            Approver vicePresident = new VicePresident();
            Approver president = new President();

            director.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);

            Purchase purchaseOne = new Purchase()
            {
                Amount = 24000,
                InvoiceNumber = 1,
                ItemName = "Mobile"
            };

            Purchase purchaseTwo = new Purchase()
            {
                Amount = 45000,
                InvoiceNumber = 2,
                ItemName = "Motor Bike"
            };

            Purchase purchaseThree = new Purchase()
            {
                Amount = 200000,
                InvoiceNumber = 3,
                ItemName = "4K TV"
            };

            Purchase purchaseFour = new Purchase()
            {
                Amount = 500000,
                InvoiceNumber = 4,
                ItemName = "Car"
            };

            director.ProcessRequest(purchaseOne);
            director.ProcessRequest(purchaseTwo);
            director.ProcessRequest(purchaseThree);
            director.ProcessRequest(purchaseFour);

            Console.Read();
        }
    }

    abstract class Approver
    {
        protected Approver Successor { get; set; }

        public void SetSuccessor(Approver successor)
        {
            this.Successor = successor;
        }

        public abstract void ProcessRequest(Purchase purchase);
    }

    class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 25000)
            {
                Console.WriteLine($"{this.GetType().Name} has approved the purchase having invoice # {purchase.InvoiceNumber}");
            }
            else if(Successor != null)
            {
                Successor.ProcessRequest(purchase);
            }
        }
    }

    class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 50000)
            {
                Console.WriteLine($"{this.GetType().Name} has approved the purchase having invoice # {purchase.InvoiceNumber}");
            }
            else if (Successor != null)
            {
                Successor.ProcessRequest(purchase);
            }
        }
    }

    class President : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount > 50000 && purchase.Amount < 250000)
            {
                Console.WriteLine($"{this.GetType().Name} has approved the purchase having invoice # {purchase.InvoiceNumber}");
            }
            else
            {
                Console.WriteLine($"Purchase having invoice # {purchase.InvoiceNumber} needs to be approved in executive meeting");
            }
        }
    }

    public class Purchase
    {
        public int Amount { get; set; }
        public int InvoiceNumber { get; set; }
        public string ItemName { get; set; }
    }
}
