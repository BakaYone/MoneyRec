using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MoneyRec.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MoneyRec.WPF.ViewModels.MainViewModels
{
    public partial class CategoriesVM : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Category> _categories;

        public CategoriesVM()
        {
            Refresh();
        }

        void Refresh()
        {
            Categories = new ObservableCollection<Category>(App.Context.Categories.ToList());
        }

        [RelayCommand]
        void Add()
        {

        }
    }
}
