using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MoneyRec.Core.Models;
using MoneyRec.WPF.ManageDialogWindows;
using MoneyRec.WPF.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.IO;
using System.Text;
using System.Windows;

namespace MoneyRec.WPF.ViewModels.MainViewModels
{
    public partial class TransactionsVM : ObservableObject
    {

        [ObservableProperty]
        ObservableCollection<Transaction> _transactions;

        
        public TransactionsVM()
        {
            Selected = null;
            _manageWindow = new TransactionManageWindow(this);
            _isManage = true;
            Refresh();
        }

        void Refresh()
        {
            
            //Transactions = new ObservableCollection<Transaction>(JsonConvert.DeserializeObject(File.ReadAllText(JSONSaver._path), List<Transaction>));
        }


        [ObservableProperty]
        Transaction? _selected;
        bool _isManage;
        Window _manageWindow;

        [ObservableProperty]
        string _description;

        [ObservableProperty]
        ObservableCollection<Category> _categories;
        [ObservableProperty]
        Category _selectedCategory;
        [ObservableProperty]
        ObservableCollection<Account> _accounts;
        [ObservableProperty]
        Account _selectedAccount;
        [ObservableProperty]
        DateTime _createdAt;
        [ObservableProperty]
        decimal _amount;

        void InitializeFields()
        {
            Categories = new ObservableCollection<Category>(App.Context.Categories.ToList());
            Accounts = new ObservableCollection<Account>(App.Context.Accounts.ToList());
        }

        [RelayCommand]
        void Add()
        {
            Selected = new Transaction();
            Selected.Category = Categories[0];
            Selected.Account = Accounts[0];
            _isManage = false;
            Manage();
        }

        [RelayCommand]
        void Manage()
        {
            InitializeFields();
            Description = Selected.Description ?? "";
            Amount = Selected.Amount;
            SelectedCategory = Selected.Category;
            SelectedAccount = Selected.Account;
            CreatedAt = Selected.CreatedAt;
            _manageWindow.ShowDialog();
        }

        [RelayCommand]
        void Submit()
        {
            Selected.Description = Description;
            Selected.Category = SelectedCategory as Category;
            Selected.Account = SelectedAccount as Account;
            Selected.CreatedAt = CreatedAt;
            Selected.Amount = Amount;
            if (Selected is not null)
            {
                if (_isManage)
                {
                    App.Context.Transactions.Update(Selected);
                }
                else
                {
                    App.Context.Transactions.Add(Selected);
                }
                App.Context.SaveChanges();
                _isManage = true;
                _manageWindow.Hide();
                Refresh();
            }
        }
    }
}
