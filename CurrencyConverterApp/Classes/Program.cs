using CurrencyAppConverter.Classes;
using CurrencyAppConverter.Interfaces;
using CurrencyConverterApp;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Net.Http;
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
