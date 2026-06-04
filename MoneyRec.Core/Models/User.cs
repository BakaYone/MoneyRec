using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyRec.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Transaction> Transactions { get; set; } = new();

        public User(string login, string email, string password)
        {
            Login = login;
            Email = email;
            Password = password;
        }
        public User() : this(string.Empty, string.Empty, string.Empty)
        {
            
        }

    }
}
