using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MoneyRec.Core.Models;
using MoneyRec.WPF.ManageDialogWindows.CategoriesManage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MoneyRec.WPF.ViewModels.MainViewModels
{
    /// <summary>
    /// Класс для логики страницы категорий
    /// </summary>
    public partial class CategoriesVM : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Category> _categories;


        [ObservableProperty]
        Category? _selected;
        bool _isManage;
        [ObservableProperty]
        string _title;
        Window _manageWindow;
        public CategoriesVM()
        {
            _isManage = true;
            _manageWindow = new CategoryManageWindow(this);
            _title = "";
            Refresh();
        }

        void Refresh()
        {
            Categories = new ObservableCollection<Category>(App.Context.Categories.ToList());
        }

        [RelayCommand]
        void Add()
        {
            Selected = new Category();
            _isManage = false;
            Manage();
        }

        [RelayCommand]
        void Manage()
        {
            Title = Selected.Title;
            _manageWindow.ShowDialog();
        }

        [RelayCommand]
        void Submit()
        {
            Selected.Title = Title;
            if (Selected is not null)
            {
                if (_isManage)
                {
                    App.Context.Categories.Update(Selected);
                }
                else
                {
                    App.Context.Categories.Add(Selected);
                }
            }
            App.Context.SaveChanges();
            _isManage = true;
            _manageWindow.Hide();
            Refresh();
        }
    }
}
