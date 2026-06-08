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
    /// Логика взаимодействия для ProfileManageWindow.xaml
    /// </summary>
    public partial class ProfileManageWindow : Window
    {
        public ProfileManageWindow(ProfileVM dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
        }
    }
}
