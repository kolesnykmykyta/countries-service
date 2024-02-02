using CountriesService.ApiDataAccess;
using CountriesService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CountriesService
{
    public class CountryDataProcessing
    {
        private readonly IApiRequest _apirequester;

        public CountryDataProcessing(IApiRequest apirequester)
        {
            _apirequester = apirequester;
        }

        public async Task<CountryModel> GetCountryInfoByCodeAsync(string countryCode)
        {
            throw new NotImplementedException();
        }

        public async Task<CountryModel> GetCountryInfoByNameAsync(string countryName)
        {
            throw new NotImplementedException();
        }

        public async Task<CountryModel> GetCountryInfoByCapitalAsync(string capitalName)
        {
            throw new NotImplementedException();
        }

        private static async Task<CountryModel> ConvertJsonIntoCountryModelAsync(string json)
        {
            try
            {
                JsonDocument document;
                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                {
                    document = await JsonDocument.ParseAsync(stream);
                }

                JsonElement rootElement = document.RootElement;

                CountryModel output = new CountryModel()
                {
                    Name = rootElement.EnumerateArray().FirstOrDefault().GetProperty("name").GetProperty("common").GetString(),
                    Currency = new CurrencyModel()
                    {
                        Code = rootElement.EnumerateArray().FirstOrDefault().GetProperty("currencies").EnumerateObject().FirstOrDefault().Name,
                        Name = rootElement.EnumerateArray().FirstOrDefault().GetProperty("currencies").EnumerateObject().FirstOrDefault().Value.GetProperty("name").GetString(),
                        Symbol = rootElement.EnumerateArray().FirstOrDefault().GetProperty("currencies").EnumerateObject().FirstOrDefault().Value.GetProperty("symbol").GetString(),
                    }
                };

                return output;
            }
            catch (JsonException ex)
            {
                throw new ArgumentException($"Exception when parsing JSON into model: {ex.Message}");
            }
        }
    }
}
