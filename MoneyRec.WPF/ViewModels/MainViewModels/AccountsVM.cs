using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MoneyRec.Core.Models;
using MoneyRec.WPF.ManageDialogWindows;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MoneyRec.WPF.ViewModels.MainViewModels
{
    public partial class AccountsVM : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Account> _accounts;
        List<Account> _accountsList;

        Window _manageWindow;
        [ObservableProperty]
        Account? _selected;
        [ObservableProperty]
        string _title;
        [ObservableProperty]
        decimal _balance;
        bool _isManage;
        public AccountsVM()
        {
            _isManage = true;
            _title = string.Empty;
            Balance = 0;
            Refresh();
            _manageWindow = new AccountManageWindow(this);
        }

        void Refresh()
        {
            _accountsList = App.Context.Accounts.ToList();
            Accounts = new ObservableCollection<Account>(_accountsList);
        }

        [RelayCommand]
        void Add()
        {
            Selected = null;
            Selected = new Account();
            _isManage = false;
            Manage();
        }

        [RelayCommand]
        void Manage()
        {
            Title = Selected.Title;
            Balance = Selected.Balance;
            _manageWindow.ShowDialog();
        }

        [RelayCommand]
        void SubmitManage()
        {
            Selected.Title = Title;
            Selected.Balance = Balance;
            if (!_isManage)
            {
                App.Context.Accounts.Add(Selected);
            }
            else
            {
                App.Context.Accounts.Update(Selected);
            }
            App.Context.SaveChanges();
            _manageWindow.Hide();
            _isManage = true;
            Refresh();
        }

        [RelayCommand]
        void Delete(KeyEventArgs e)
        {
            if (Selected is not null && e.Key == Key.Delete)
            {
                App.Context.Accounts.Remove(Selected);
                App.Context.SaveChanges();
                Refresh();
            }
        }
    }
}
