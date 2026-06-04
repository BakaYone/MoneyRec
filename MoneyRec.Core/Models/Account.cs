using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyRec.Core.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; } = new();
        public Account(string title)
        {
            Title = title;
            Balance = 0;
        }
        public Account() : this(string.Empty)
        {
            
        }
    }
}
