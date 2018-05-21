using System;

namespace FactoryMethod
{
    static class Program
    {
        private static void Main()
        {
            ISavingsAccountFactory savingsAccountFactory = new SavingsAccountFactory();
            SavingsAccount regularSavingsAccount = savingsAccountFactory.CreateSavingsAccount(500000);
            SavingsAccount privilegeSavingsAccount = savingsAccountFactory.CreateSavingsAccount(5000000);

            Console.WriteLine($"Min Balance of Regular Savings Account ${regularSavingsAccount.Balance}");
            Console.WriteLine($"Min Balance of Privilege Savings Account ${privilegeSavingsAccount.Balance}");
            Console.Read();
        }
    }

    public abstract class SavingsAccount
    {
        public decimal Balance { get; set; }
    }

    public class RegularSavingsAccount : SavingsAccount
    {
        public RegularSavingsAccount()
        {
            Balance = 5000;
        }
    }

    public class PrivilegeSavingsAccount : SavingsAccount
    {
        public PrivilegeSavingsAccount()
        {
            Balance = 100000;
        }
    }

    public interface ISavingsAccountFactory
    {
        SavingsAccount CreateSavingsAccount(int income);
    }
    
    public class SavingsAccountFactory : ISavingsAccountFactory
    {
        public SavingsAccount CreateSavingsAccount(int income)
        {
            if (income <= 1000000)
            {
                return new RegularSavingsAccount();
            }
            else
            {
                return new PrivilegeSavingsAccount();
            }
        }
    }
}
