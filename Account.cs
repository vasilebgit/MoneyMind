using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMind
{
    internal class Account
    {
        public string Name { get; }
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }

        public Account(string name, string accountNumber, decimal balance)
        {
            Name = name;
            AccountNumber = accountNumber;
            Balance = balance;
        }

        

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.", nameof(amount));
            }

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.", nameof(amount));
            }

            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }

            Balance -= amount;
        }

        public decimal GetTotalSpending(string accountNumber, List<Transaction> transactions)
        {
            decimal totalSpending = 0;
            foreach (Transaction transaction in transactions)
            {
                if (transaction.AccountNumber == accountNumber && transaction.Amount < 0)
                {
                    totalSpending += Math.Abs(transaction.Amount);
                }
            }
            return totalSpending;
        }

    }
}
