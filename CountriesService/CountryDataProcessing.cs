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
        const string targetedApi = "https://restcountries.com/v3.1/";

        public CountryDataProcessing(IApiRequest apirequester)
        {
            _apirequester = apirequester;
        }

        public async Task<CountryModel> GetCountryInfoByCodeAsync(string? countryCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(countryCode))
                {
                    throw new ArgumentException("CountryCode is null, empty or whitespace.");
                }
                string request = $"{targetedApi}alpha/{countryCode}?fields=name,capital,area,population,flags,currencies,region";

                string jsonData = await _apirequester.GetJsonFromApiAsync(request);

                CountryModel output = await ConvertJsonIntoCountryModelAsync(jsonData);

                return output;
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch (JsonException ex)
            {
                throw new ArgumentException(ex.Message);
            }
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
                    Name = rootElement.GetProperty("name").GetProperty("common").GetString(),
                    Currency = new CurrencyModel()
                    {
                        Code = rootElement.GetProperty("currencies").EnumerateObject().FirstOrDefault().Name,
                        Name = rootElement.GetProperty("currencies").EnumerateObject().FirstOrDefault().Value.GetProperty("name").GetString(),
                        Symbol = rootElement.GetProperty("currencies").EnumerateObject().FirstOrDefault().Value.GetProperty("symbol").GetString(),
                    },
                    Capital = rootElement.GetProperty("capital").EnumerateArray().FirstOrDefault().GetString(),
                    Region = rootElement.GetProperty("region").GetString(),
                    Area = rootElement.GetProperty("area").GetDouble(),
                    Population = rootElement.GetProperty("population").GetInt32(),
                    FlagURL = rootElement.GetProperty("flags").GetProperty("png").GetString(),
                };

                return output;
            }
            catch (Exception ex)
            {
                throw new JsonException($"Exception when parsing JSON into model: {ex.Message}");
            }
        }
    }
}
