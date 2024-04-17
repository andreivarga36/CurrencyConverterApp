using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyAppConverter.Interfaces
{
    public interface IApiService
    {
        Task<string> RetrieveCurrencies(string apiKey);

        Dictionary<string, double> GetCurrencies(string response);

        void DisposeClient();
    }
}
