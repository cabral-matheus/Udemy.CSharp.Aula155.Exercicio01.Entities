using Udemy.CSharp.Aula155.Exercicio01.Entities.Exceptions;

namespace Udemy.CSharp.Aula155.Exercicio01.Entities
{
    internal class Account
    {
        public int Number { get; private set; }
        public string Holder { get; set; }
        public double Balance { get; private set; }
        public double WithdrawLimit { get; set; }

        public Account(int number, string holder, double balance, double withdrawLimit)
        {
            if (balance < 0)
            {
                throw new DomainException("The balance must not be negative.");
            }

            if (withdrawLimit <= 0)
            {
                throw new DomainException("The withdraw limit must be positive.");
            }

            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double amount)
        {
            if (amount < 0.0)
            {
                throw new DomainException("The amount to deposit must be greater than 0.");
            }

            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount > WithdrawLimit)
            {
                throw new DomainException("The amount exceeds withdraw limit.");
            }

            if (Balance < amount)
            {
                throw new DomainException("Not enough balance.");
            }

            if (amount < 0.0)
            {
                throw new DomainException("The amount to withdraw must be greater than 0.");
            }

            Balance -= amount;
        }
    }
}
