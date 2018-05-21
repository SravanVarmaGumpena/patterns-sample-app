using System;
using System.Collections.Generic;

namespace AbstractFactory
{
    class Program
    {
        static void Main()
        {
            List<string> accountTypes = new List<string>()
            {
                "P", "R"
            };

            foreach (string accountType in accountTypes)
            {
                AccountFactory accountFactory = AccountFactoryProvider.GetAccountFactory(accountType);
                accountFactory.CreateSavingsAccount();
                accountFactory.CreateLoanAccount();
            }
            
            Console.Read();
        }
    }

    public interface ISavingsAccount
    {
    }

    public class RegularSavingsAccount : ISavingsAccount
    {
        public RegularSavingsAccount()
        {
            Console.WriteLine("Returned RegularSavingsAccount");
        }
    }

    public class PrivilegeSavingsAccount : ISavingsAccount
    {
        public PrivilegeSavingsAccount()
        {
            Console.WriteLine("Returned PrivilegeSavingsAccount");
        }
    }

    public interface ILoanAccount
    {
    }

    public class RegularLoanAccount : ILoanAccount
    {
        public RegularLoanAccount()
        {
            Console.WriteLine("Returned RegularLoanAccount");
        }
    }

    public class PrivilegeLoanAccount : ILoanAccount
    {
        public PrivilegeLoanAccount()
        {
            Console.WriteLine("Returned PrivilegeLoanAccount");
        }
    }

    public abstract class AccountFactory
    {
        public abstract ISavingsAccount CreateSavingsAccount();
        public abstract ILoanAccount CreateLoanAccount();
    }

    public class RegularAccountFactory : AccountFactory
    {
        public override ISavingsAccount CreateSavingsAccount()
        {
            return new RegularSavingsAccount();
        }

        public override ILoanAccount CreateLoanAccount()
        {
            return new RegularLoanAccount();
        }
    }

    public class PrivilegeAccountFactory : AccountFactory
    {
        public override ISavingsAccount CreateSavingsAccount()
        {
            return new PrivilegeSavingsAccount();
        }

        public override ILoanAccount CreateLoanAccount()
        {
            return new PrivilegeLoanAccount();
        }
    }

    public static class AccountFactoryProvider
    {
        public static AccountFactory GetAccountFactory(string accountType)
        {
            if (accountType.Contains("P"))
            {
                return new PrivilegeAccountFactory();
            }
            else
            {
                return new RegularAccountFactory();
            }
        }
    }
}
