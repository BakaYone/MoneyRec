using MoneyRec.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MoneyRec.WPF.Services
{
    public static class JSONSaver
    {
        public static readonly string _path = "Data.json";
        

        static JSONSaver()
        {
            if (!File.Exists(_path))
            {
                File.Create(_path);
            }
        }

        public static void Save()
        {
            File.WriteAllText(_path, JsonConvert.SerializeObject(App.Context.Transactions.Where(t => t.UserId == App.User.Id).ToList(), Formatting.Indented));
        }
    }
}
