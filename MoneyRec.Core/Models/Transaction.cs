using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MoneyRec.Core.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public User User { get; set; } = new();
        public int UserId { get; set; }
        public Account Account { get; set; } = new();
        public int AccountId { get; set; }
        public Category Category { get; set; } = new();
        public int CategoryId { get; set; }

        public Transaction(string description, decimal amount)
        {
            Description = description;
            Amount = amount;
        }
        public Transaction() : this(string.Empty, 0)
        {
            
        }

    }
}
