using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MoneyRec.Core.Models;
using MoneyRec.WPF.ManageDialogWindows;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MoneyRec.WPF.ViewModels.MainViewModels
{
    public partial class ProfileVM : ObservableObject
    {
        [ObservableProperty]
        string _login, _email, _password;
        Window _manageWindow;
        public ProfileVM()
        {
            Login = App.User.Login;
            Email = App.User.Email;
            Password = App.User.Password;
            _manageWindow = new ProfileManageWindow(this);
        }

        [RelayCommand]
        void Manage()
        {
            _manageWindow.ShowDialog();
        }

        [RelayCommand]
        void SubmitChanges()
        {
            App.User.Login = Login;
            App.User.Email = Email;
            App.User.Password = Password;
            App.Context.Users.Update(App.User);
            App.Context.SaveChanges();
            _manageWindow.Hide();
        }
    }
}
