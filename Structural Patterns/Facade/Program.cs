using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            //Facade (fəˈsɑːd/)
            PersonalLoan personalLoan = new PersonalLoan(1000000); // Personal Loan of 10 Lakh

            //Person 1
            Person personOne = new Person()
            {
                Name = "Person1",
                AccountBalance = 3000000,
                CreditScore = 800,
                ExistingLoans = 1,
                LoansDefaulted = 0
            };

            //Person 2
            Person personTwo = new Person()
            {
                Name = "Person2",
                AccountBalance = 3000000,
                CreditScore = 600,
                ExistingLoans = 1,
                LoansDefaulted = 1
            };

            //Evaluate Loan for Person 1
            bool isEligibleForPersonOne = personalLoan.IsEligible(personOne);
            Console.WriteLine($"Loan Status for {personOne.Name} is {(isEligibleForPersonOne ? "approved" : "rejected")}");

            //Evaluate Loan for Person 2
            bool isEligibleForPersonTwo = personalLoan.IsEligible(personTwo);            
            Console.WriteLine($"Loan Status for {personTwo.Name} is {(isEligibleForPersonTwo ? "approved" : "rejected")}");

            Console.Read();
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int AccountBalance { get; set; }
        public int CreditScore { get; set; }
        public int ExistingLoans { get; internal set; }
        public int LoansDefaulted { get; internal set; }
    }

    public class PersonalLoan
    {
        public int LoanAmount { get; private set; }

        public PersonalLoan(int loanAmount)
        {
            LoanAmount = loanAmount;
        }
        private SavingsHistory savingsHistory = new SavingsHistory();
        private CreditHistory creditHistory = new CreditHistory();
        private LoanHistory loanHistory = new LoanHistory();     

        public bool IsEligible(Person person)
        {
            bool isEligible = false;

            if (savingsHistory.HasSufficientSavings(person, LoanAmount) && 
                creditHistory.HasGoodCreditScore(person) && 
                !loanHistory.HasAnyBadLoans(person))
            {
                isEligible = true;
            }

            return isEligible;
        }
    }

    public class SavingsHistory
    {
        public bool HasSufficientSavings(Person person, int loanAmount)
        {
            bool hasSufficientSavings = false;

            if(((person.AccountBalance / loanAmount) * 100) >= 20)
            {
                hasSufficientSavings = true;
            }

            return hasSufficientSavings;
        }
    }

    public class CreditHistory
    {
        public bool HasGoodCreditScore(Person person)
        {
            bool hasGoodCreditScore = false;

            if (person.CreditScore >= 750)
            {
                hasGoodCreditScore = true;
            }

            return hasGoodCreditScore;
        }
    }

    public class LoanHistory
    {
        public bool HasAnyBadLoans(Person person)
        {
            bool hasAnyBadLoans = false;

            if(person.ExistingLoans >= 3 && person.LoansDefaulted > 0)
            {
                hasAnyBadLoans = true;
            }

            return hasAnyBadLoans;
        }
    }
}
