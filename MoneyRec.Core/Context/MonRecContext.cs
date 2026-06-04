using Microsoft.EntityFrameworkCore;
using MoneyRec.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyRec.Core.Context
{
    public class MonRecContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public MonRecContext()
        {
            
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<User>(u =>
            {
                u.HasData(new User { Id = 1, Login = "TestUser", Email = "test@mail.com", Password = "qwerty"});
            });
            mb.Entity<Transaction>(t =>
            {

            });
            mb.Entity<Category>(c =>
            {
                c.HasData(new Category { Id = 1, Title = "Продукты"}, new Category { Id = 2, Title = "Аптека"}, new Category { Id = 3, Title = "Спорт"});
            });
            mb.Entity<Account>(a =>
            {
                a.HasData(new Account { Id = 1, Balance = 0, Title = "Карта" }, new Account { Id = 2, Balance = 0, Title = "Наличные"});
            });
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30"));
            base.OnConfiguring(optionsBuilder.UseSqlServer(@"Data Source=BAKA\BAKASERVER;Initial Catalog = MoneyRec; Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30"));
        }
    }
}
