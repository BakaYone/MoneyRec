using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MoneyRec.WPF.ViewComponents.LoginWindowComponents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MoneyRec.WPF.ViewModels.AuthorizationViewModels
{
    public partial class AuthorizationVM : ObservableObject
    {
        Page _loginInstance;
        Page _registrationInstance;
        [ObservableProperty]
        Page _currentInstance;
        [ObservableProperty]
        string _buttonName;
        public AuthorizationVM()
        {
            ButtonName = "Регистрация";
            _loginInstance = new LoginPage();
            _registrationInstance = new RegistrationPage();
            _currentInstance = _loginInstance;
        }

        [RelayCommand]
        void ChangeInstance()
        {
            if (CurrentInstance is LoginPage)
            {
                ButtonName = "Вход";
                CurrentInstance = _registrationInstance;
            }
            else
            {
                ButtonName = "Регистрация";
                CurrentInstance = _loginInstance;
            }
        }
    }
}
