
using System.Collections.Generic;

public class Category
{
    public string Name { get; }
    public decimal BudgetedAmount { get; }
    public List<Transaction> Transactions { get; }

    public Category(string name, decimal budgetedAmount)
    {
        Name = name;
        BudgetedAmount = budgetedAmount;
        Transactions = new List<Transaction>();
    }

    public void AddTransaction(Transaction transaction)
    {
        Transactions.Add(transaction);
    }

    public void RemoveTransaction(Transaction transaction)
    {
        Transactions.Remove(transaction);
    }

    public decimal GetTotalSpending()
    {
        decimal total = 0;

        foreach (Transaction transaction in Transactions)
        {
            total += transaction.Amount;
        }

        return total;
    }

    public decimal GetRemainingAmount()
    {
        return BudgetedAmount - GetTotalSpending();
    }
}