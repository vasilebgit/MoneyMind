using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MoneyMind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            // Set starting account balance
            menu.SetAccountBalance(1000);

            // Create budgets
            Budget foodBudget = new Budget("Food", 300);
            Budget entertainmentBudget = new Budget("Entertainment", 200);

            menu.AddBudget(foodBudget);
            menu.AddBudget(entertainmentBudget);

            // Create categories
            Category groceriesCategory = new Category("Groceries", 150);
            Category restaurantsCategory = new Category("Restaurants", 150);
            Category moviesCategory = new Category("Movies", 100);
            Category gamesCategory = new Category("Games", 100);

            foodBudget.AddCategory(groceriesCategory);
            foodBudget.AddCategory(restaurantsCategory);
            entertainmentBudget.AddCategory(moviesCategory);
            entertainmentBudget.AddCategory(gamesCategory);

            // Add transactions
            Transaction groceries1 = new Transaction("Walmart", 75);
            Transaction groceries2 = new Transaction("Kroger", 50);
            Transaction restaurant1 = new Transaction("McDonald's", 10);
            Transaction restaurant2 = new Transaction("Chili's", 30);
            Transaction movie1 = new Transaction("AMC", 20);
            Transaction game1 = new Transaction("Steam", 30);

            groceriesCategory.AddTransaction(groceries1);
            groceriesCategory.AddTransaction(groceries2);
            restaurantsCategory.AddTransaction(restaurant1);
            restaurantsCategory.AddTransaction(restaurant2);
            moviesCategory.AddTransaction(movie1);
            gamesCategory.AddTransaction(game1);

            // Start menu
            menu.Start();
        }
    }
}
    }
}
