﻿using CurrencyAppConverter.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyAppConverter.Classes
{
    public class ApiService : IApiService
    {
        private readonly HttpClient httpClient;

        public ApiService()
        {
            httpClient = new HttpClient();
        }

        public ApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        private static void AddCurrencies(dynamic deserializedApiResponse, Dictionary<string, double> currencies)
        {
            foreach (var item in deserializedApiResponse.data)
            {
                currencies.Add(item.Name, item.First.value.Value);
            }
        }

        public Dictionary<string, double> DeserializeCurrencies(string response)
        {
            try
            {
                dynamic deserializedApiResponse = JsonConvert.DeserializeObject(response);

                var currencies = new Dictionary<string, double>();
                AddCurrencies(deserializedApiResponse, currencies);

                return currencies;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, nameof(response));
            }
        }

        public void DisposeHttpClient()
        {
            httpClient.Dispose();
        }

        public async Task<string> GetCurrenciesDataAsync(string apiKey)
        {
            try
            {
                return await HandleApiResponse(apiKey);
            }
            catch (HttpRequestException ex)
            {
                string errorMessage = "Failed to retrieve currencies, please try again later!";
                throw new InvalidOperationException(errorMessage, ex);
            }
        }

        private async Task<string> HandleApiResponse(string apiKey)
        {
            string requestUrl = $"https://api.currencyapi.com/v3/latest?apikey={apiKey}";

            using (HttpResponseMessage response = await httpClient.GetAsync(requestUrl))
            {
                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = $"API request failed with status code: {response.StatusCode}";
                    throw new HttpRequestException(errorMessage);
                }

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
