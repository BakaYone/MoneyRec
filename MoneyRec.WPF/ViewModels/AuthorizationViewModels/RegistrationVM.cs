using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MoneyRec.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media.Animation;

namespace MoneyRec.WPF.ViewModels.AuthorizationViewModels
{
    /// <summary>
    /// Класс для логики страницы регистрации
    /// </summary>
    public partial class RegistrationVM : ObservableObject
    {
        [ObservableProperty]
        string _login, _email, _password, _rePassword;
        User? _user;

        public RegistrationVM()
        {
            _login = _email = _password = _rePassword = string.Empty;
        }

        [RelayCommand]
        void Submit()
        {
            if (CheckCurrency(Login) && CheckCurrency(Password) && CheckEmailCurrency())
            {
                CreateUser();
                MessageBox.Show("Успешно!");
            }
        }

        bool CheckRePassword()
        {
            return Password == RePassword;
        }

        async void CreateUser()
        {
            _user = new User(Login, Email, Password);
            App.Context.Users.Add(_user);
            await App.Context.SaveChangesAsync();
        }

        bool CheckEmailCurrency()
        {
            Regex regex = new Regex(@"^\w+@[A-z]+.[a-z]+$", RegexOptions.Compiled);
            return regex.IsMatch(Email);
        }

        bool CheckCurrency(string str)
        {
            if (!string.IsNullOrWhiteSpace(str) && char.IsLetter(str[0]))
            {
                foreach (char ch in str)
                {
                    if (!char.IsLetterOrDigit(ch))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
