using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Budget
{
    public string Name { get; }
    public decimal Amount { get; }
    public List<Category> Categories { get; }

    public Budget(string name, decimal amount)
    {
        Name = name;
        Amount = amount;
        Categories = new List<Category>();
    }

    public void AddCategory(Category category)
    {
        Categories.Add(category);
    }

    public void RemoveCategory(Category category)
    {
        Categories.Remove(category);
    }

    public decimal GetTotalSpending()
    {
        decimal total = 0;

        foreach (Category category in Categories)
        {
            total += category.GetTotalSpending();
        }

        return total;
    }

    public decimal GetRemainingAmount()
    {
        return Amount - GetTotalSpending();
    }
}