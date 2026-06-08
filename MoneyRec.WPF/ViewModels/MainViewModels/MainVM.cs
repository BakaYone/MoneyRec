using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Identity.Client;
using MoneyRec.WPF.ViewComponents.MainWindowComponents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace MoneyRec.WPF.ViewModels.MainViewModels
{
    /// <summary>
    /// Класс для логики основного окна
    /// </summary>
    public partial class MainVM : ObservableObject
    {
        [ObservableProperty]
        Page _currentInstance;
        [ObservableProperty]
        string _pageLabel;
        Page[] _pages;

        public MainVM()
        {
            _pages = new Page[] { new ProfilePage(), new AccountsPage(), new CategoriesPage(), new TransactionsPage()};
            CurrentInstance = _pages[0];
            PageLabel = CurrentInstance.Title;
        }


        [RelayCommand]
        void ChangeInstance(object index)
        {

            if (_pages[Convert.ToInt32(index)] != CurrentInstance)
            {
                CurrentInstance = _pages[Convert.ToInt32(index)];
                PageLabel = CurrentInstance.Title;
            }
        }
    }
}
