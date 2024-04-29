using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyAppConverter.Interfaces
{
    public interface IApiService
    {
        Task<string> GetCurrenciesDataAsync(string apiKey);

        Dictionary<string, double> DeserializeCurrencies(string response);

        void DisposeHttpClient();
    }
}
