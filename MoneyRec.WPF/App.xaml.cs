using MoneyRec.Core.Context;
using MoneyRec.Core.Models;
using System.Configuration;
using System.Data;
using System.Net.Http;
using System.Windows;

namespace MoneyRec.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static HttpClient Client;
        public static MonRecContext Context;
        public static User User;
        
        static App()
        {
            User = null!;
            Client = new();
            Context = new();
        }
    }

}
