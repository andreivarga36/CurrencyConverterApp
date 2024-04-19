using CurrencyAppConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurrencyConverterApp
{
    public partial class CurrencyConverter : Form
    {
        private readonly IApiService apiService;
        private readonly string apiKey;
        private Dictionary<string, double> currencies;
        private bool currenciesPopulated;

        public CurrencyConverter(IApiService apiService, string apiKey)
        {
            InitializeComponent();

            this.apiKey = apiKey;
            this.apiService = apiService;
            currencies = new Dictionary<string, double>();
        }

        private async Task RetrieveCurrencyRates()
        {
            try
            {
                string response = await apiService.GetCurrenciesDataAsync(apiKey);
                currencies = apiService.DeserializeCurrencies(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task PopulateCurrencyComboBoxesAsync()
        {
            await RetrieveCurrencyRates();

            foreach (var item in currencies.Select(x => x.Key))
            {
                sourceCurrencyComboBox.Items.Add(item);
                destinationCurrencyComboBox.Items.Add(item);
            }
        }

        private async void HandleCurrencyComboBoxesPopulation(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (!currenciesPopulated && (comboBox == sourceCurrencyComboBox || comboBox == destinationCurrencyComboBox))
            {
                await PopulateCurrencyComboBoxesAsync();
                currenciesPopulated = true;
            }
        }
    }
}

