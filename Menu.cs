using MoneyMind;



using System;
using System.Collections.Generic;

public class Menu
{
    private Account _account;
    private List<Budget> _budgets;
    private List<Transaction> _transactions;

    public Menu()
    {
        _account = new Account("", "", 0);
        _budgets = new List<Budget>();
        _transactions = new List<Transaction>();
    }

    public void Start()
    {
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Create a new budget");
            Console.WriteLine("2. Create a new category");
            Console.WriteLine("3. Add a transaction");
            Console.WriteLine("4. View account details");
            Console.WriteLine("5. Quit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateBudget();
                    break;
                case 2:
                    CreateCategory();
                    break;
                case 3:
                    AddTransaction();
                    break;
                case 4:
                    ViewAccountDetails();
                    break;
                case 5:
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void CreateBudget()
    {
        Console.WriteLine("Enter budget name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter budget amount:");
        decimal amount = decimal.Parse(Console.ReadLine());

        Budget budget = new Budget(name, amount);
        _budgets.Add(budget);

        Console.WriteLine("Budget created.");
    }

    private void CreateCategory()
    {
        Console.WriteLine("Enter budget name:");
        string budgetName = Console.ReadLine();

        Budget budget = _budgets.Find(b => b.Name == budgetName);

        if (budget == null)
        {
            Console.WriteLine("Budget not found.");
            return;
        }

        Console.WriteLine("Enter category name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter category budgeted amount:");
        decimal budgetedAmount = decimal.Parse(Console.ReadLine());

        Category category = new Category(name, budgetedAmount);
        budget.AddCategory(category);

        Console.WriteLine("Category created.");
    }

    private void AddTransaction()
    {
        Console.WriteLine("Enter budget name:");
        string budgetName = Console.ReadLine();

        Budget budget = _budgets.Find(b => b.Name == budgetName);

        if (budget == null)
        {
            Console.WriteLine("Budget not found.");
            return;
        }

        Console.WriteLine("Enter category name:");
        string categoryName = Console.ReadLine();

        Category category = budget.Categories.Find(c => c.Name == categoryName);

        if (category == null)
        {
            Console.WriteLine("Category not found.");
            return;
        }

        Console.WriteLine("Enter transaction name:");
        string transactionName = Console.ReadLine();

        Console.WriteLine("Enter transaction amount:");
        decimal transactionAmount = decimal.Parse(Console.ReadLine());

        Transaction transaction = new Transaction(transactionName, transactionAmount );
        category.AddTransaction(transaction);

        Console.WriteLine("Transaction added.");
    }

    private void ViewAccountDetails()
    {
        Console.WriteLine("Account balance: $" + _account.Balance);
        Console.WriteLine("Total spending: $" + _account.GetTotalSpending(_account.AccountNumber, _transactions));

        foreach (Budget budget in _budgets)
        {
            Console.WriteLine("Budget: " + budget.Name + " ($" + budget.Amount + ")");

            foreach (Category category in budget.Categories)
            {
                Console.WriteLine("  Category: " + category.Name + " ($" + category.BudgetedAmount + ")");
                Console.WriteLine("  Spending in category: $" + category.GetTotalSpending());
                Console.WriteLine("  Remaining budget for category: $" + (category.BudgetedAmount - category.GetTotalSpending()));
            }
            Console.WriteLine(" Transactions:");
        }
    }

    internal void SetAccountBalance(int v)
    {
        _account.Deposit(v);
    }

}

