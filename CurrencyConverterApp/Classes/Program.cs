using CurrencyAppConverter.Classes;
using CurrencyConverterApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurrencyAppConverter
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string apiKey = File.ReadAllText("api.txt");
            var apiService = new ApiService();

            Application.Run(new CurrencyConverter(apiService, apiKey));
        }
    }
}
