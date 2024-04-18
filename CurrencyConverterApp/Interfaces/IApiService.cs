using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyAppConverter.Interfaces
{
    public interface IApiService
    {
        Task<string> RetrieveCurrenciesAsync(string apiKey);

        Dictionary<string, double> GetCurrencies(string response);

        void DisposeClient();
    }
}
