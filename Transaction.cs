﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Transaction
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Category { get; set; }
    public string Notes { get; set; }

    public Transaction(decimal amount, DateTime date, string category, string notes)
    {
        Amount = amount;
        Date = date;
        Category = category;
        Notes = notes;
    }
}