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
        public DateTime CreatedAt { get; set; }
        public User User { get; set; } = new();
        public int UserId { get; set; }
        public Account Account { get; set; } = new();
        public int AccountId { get; set; }
        public Category Category { get; set; } = new();
        public int CategoryId { get; set; }

        public Transaction(string description, decimal amount, DateTime createdAt)
        {
            Description = description;
            Amount = amount;
            CreatedAt = createdAt;
        }
        public Transaction() : this(string.Empty, 0, DateTime.Now)
        {
            
        }

    }
}
