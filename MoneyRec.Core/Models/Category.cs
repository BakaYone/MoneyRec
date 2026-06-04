using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyRec.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Transaction> Transactions { get; set; } = new();

        public Category(string title)
        {
            Title = title;
        }
        public Category() : this(string.Empty)
        {
            
        }
    }
}
