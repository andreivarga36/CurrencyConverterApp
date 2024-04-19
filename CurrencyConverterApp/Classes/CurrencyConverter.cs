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

        private void HandleConvertButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (ValidateUserInput())
                {
                    CalculateAndDisplayConvertedAmount();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private double CalculateConvertedAmount(double amount, string sourceCurrency, string destinationCurrency)
        {
            var sourceCurrencyExchangeRate = currencies.First(c => c.Key == sourceCurrency).Value;
            var destinationCurrencyExchangeRate = currencies.First(c => c.Key == destinationCurrency).Value;

            return amount * (destinationCurrencyExchangeRate / sourceCurrencyExchangeRate);
        }

        private void CalculateAndDisplayConvertedAmount()
        {
            var sourceCurrency = sourceCurrencyComboBox.Text;
            var destinationCurrency = destinationCurrencyComboBox.Text;
            var amount = double.Parse(amountTextBox.Text);

            var convertedAmount = CalculateConvertedAmount(amount, sourceCurrency, destinationCurrency);

            DisplayConvertedAmount(convertedAmount);
        }

        private void DisplayConvertedAmount(double convertedAmount)
        {
            labTotal.Text = $"Total: {convertedAmount,10:0.00}";
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

        private bool ValidateUserInput() => ValidateSourceCurrency() && ValidateDestinationCurrency() && ValidateAmount();


        private bool ValidateSourceCurrency()
        {
            if (currencies.ContainsKey(sourceCurrencyComboBox.Text))
            {
                return true;
            }

            throw new InvalidOperationException("Please type a valid currency in \"From\" box!");
        }

        private bool ValidateDestinationCurrency()
        {
            if (currencies.ContainsKey(destinationCurrencyComboBox.Text))
            {
                return true;
            }

            throw new InvalidOperationException("Please type a valid currency in \"To\" box!");
        }

        private bool ValidateAmount()
        {
            if (double.TryParse(amountTextBox.Text, out _))
            {
                return true;
            }

            throw new InvalidOperationException("Please enter a valid amount!");
        }
    }
}

