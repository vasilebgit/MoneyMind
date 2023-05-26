using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMind
{
    public abstract class SpendingTracker
    {
        protected List<Transaction> _transactions;

        public SpendingTracker()
        {
            _transactions = new List<Transaction>();
        }

        public void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public decimal GetTotalSpending()
        {
            decimal totalSpending = 0;

            foreach (Transaction transaction in _transactions)
            {
                totalSpending += transaction.Amount;
            }

            return totalSpending;
        }
    }
}
