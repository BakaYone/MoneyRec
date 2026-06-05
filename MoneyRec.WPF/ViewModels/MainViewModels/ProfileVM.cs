using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyRec.WPF.ViewModels.MainViewModels
{
    public partial class ProfileVM : ObservableObject
    {
        [ObservableProperty]
        string _login, _email;

        public ProfileVM()
        {
            Login = App.User.Login;
            Email = App.User.Email;
        }

        [RelayCommand]
        void Manage()
        {

        }
    }
}
