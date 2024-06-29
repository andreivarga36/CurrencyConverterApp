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

            FormClosing += DisposeHttpClient;
        }

        private void DisposeHttpClient(object sender, EventArgs e)
        {
            apiService.DisposeHttpClient();
        }

        private void HandleConvertButtonClick(object sender, EventArgs e)
        {
            ClearAmount();

            try
            {
                if (IsValidAmount())
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

        private void ClearAmount()
        {
            labTotal.Text = "Total:";
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

            if (CurrenciesAreSelected() && IsValidAmount())
            {
                CalculateAndDisplayConvertedAmount();
            }
        }

        private void ComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrenciesAreSelected() && IsValidAmount())
            {
                CalculateAndDisplayConvertedAmount();
            }
        }

        private void AmountTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void AmountTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (CurrenciesAreSelected() && IsValidAmount() && e.KeyCode == Keys.Enter)
            {
                CalculateAndDisplayConvertedAmount();
            }
        }

        private void AmountTextBoxLeave(object sender, EventArgs e)
        {
            if (CurrenciesAreSelected() && IsValidAmount())
            {
                CalculateAndDisplayConvertedAmount();
            }
        }

        private bool CurrenciesAreSelected()
        {
            return sourceCurrencyComboBox.SelectedIndex != -1 && destinationCurrencyComboBox.SelectedIndex != -1;
        }

        private bool IsValidAmount()
        {
            return double.TryParse(amountTextBox.Text, out double _);
        }
    }
}

