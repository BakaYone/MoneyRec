using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MoneyRec.Core.Models;
using MoneyRec.WPF;
using MoneyRec.WPF.Views;
using System.Windows;

namespace MoneyRec.WPF.ViewModels.AuthorizationViewModels
{
    /// <summary>
    /// Класс для логики страницы входа
    /// </summary>
    public partial class LoginVM : ObservableObject
    {
        Window _instance;
        [ObservableProperty]
        string _login;
        [ObservableProperty]
        string _password;
        User? _user;

        public LoginVM()
        {
            _instance = App.Current.MainWindow;
#if DEBUG
            Login = App.Context.Users.ToList()[0].Login;
            Password = App.Context.Users.ToList()[0].Password;
#else
            Login = "";
            Password = "";
#endif
        }

        [RelayCommand]
        void Submit()
        {
            if (Verificate())
            {
                App.User = _user!;
                App.Current.MainWindow = new MainWindow();
                App.Current.MainWindow.Show();
                _instance.Close();
            }
        }

        bool Verificate()
        {
            _user = App.Context.Users.Where(u => u.Login == Login && u.Password == Password).FirstOrDefault();
            return _user is not null;
        }
    }
}
