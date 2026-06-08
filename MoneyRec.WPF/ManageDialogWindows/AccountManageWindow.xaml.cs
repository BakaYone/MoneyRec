using MoneyRec.WPF.ViewModels.MainViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MoneyRec.WPF.ManageDialogWindows
{
    /// <summary>
    /// Логика взаимодействия для AccountManageWindow.xaml
    /// </summary>
    public partial class AccountManageWindow : Window
    {
        public AccountManageWindow(AccountsVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
