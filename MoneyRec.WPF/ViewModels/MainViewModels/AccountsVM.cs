using CommunityToolkit.Mvvm.ComponentModel;
using MoneyRec.Core.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MoneyRec.WPF.ViewModels.MainViewModels
{
    public partial class AccountsVM : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Account> _accounts;
        List<Account> _accountsList;
        public AccountsVM()
        {
            Refresh();
        }

        void Refresh()
        {
            _accountsList = App.Context.Accounts.ToList();
            Accounts = new ObservableCollection<Account>(_accountsList);
        }
    }
}
