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
    /// <summary>
    /// Contains set of methods to get the country data from API by code, capital or name.
    /// </summary>
    public class CountryDataProcessing
    {
        /// <summary>
        /// Instance of IApiRequest class that will handle API requests.
        /// </summary>
        private readonly IApiRequest _apirequester;
        const string targetedApi = "https://restcountries.com/v3.1/";

        /// <summary>
        /// Initializes class with API requester.
        /// </summary>
        /// <param name="apirequester">Instance of IApiRequest class that will handle API requests.</param>
        public CountryDataProcessing(IApiRequest apirequester)
        {
            _apirequester = apirequester;
        }

        /// <summary>
        /// Provides information about the country by cca2, cca3, ccn3 or cioc country code.
        /// </summary>
        /// <param name="countryCode">cca2, cca3, ccn3 or cioc code of the country.</param>
        /// <returns>CountryModel with information about the country.</returns>
        /// <exception cref="ArgumentException">Thrown if country code is invalid, null, empty or whitespace.</exception>
        public async Task<CountryModel> GetCountryInfoByCodeAsync(string? countryCode)
        {
            if (string.IsNullOrWhiteSpace(countryCode))
            {
                throw new ArgumentException("CountryCode is null, empty or whitespace.");
            }

            try
            {
                string request = $"{targetedApi}alpha/{countryCode}?fields=name,capital,area,population,flags,currencies,region";
                string jsonData = await _apirequester.GetJsonFromApiAsync(request);
                CountryModel output = await ConvertJsonIntoCountryModelAsync(jsonData);

                return output;
            }
            catch (JsonException ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        /// <summary>
        /// Provides information about the country by common or official name.
        /// </summary>
        /// <param name="countryName">Common or official name.</param>
        /// <returns>CountryModel with information about the country.</returns>
        /// <exception cref="ArgumentException">Thrown if country name is invalid, null, empty or whitespace.</exception>
        public async Task<CountryModel> GetCountryInfoByNameAsync(string countryName)
        {
            if (string.IsNullOrWhiteSpace(countryName))
            {
                throw new ArgumentException("Country name is null, empty or whitespace.");
            }

            try
            {
                string request = $"{targetedApi}name/{countryName}?fields=name,capital,area,population,flags,currencies,region";
                string jsonData = await _apirequester.GetJsonFromApiAsync(request);
                CountryModel output = await ConvertJsonIntoCountryModelAsync(jsonData);

                return output;
            }
            catch (JsonException ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        /// <summary>
        /// Provides information about the country by capital.
        /// </summary>
        /// <param name="capitalName">Capital of the country.</param>
        /// <returns>CountryModel with information about the country.</returns>
        /// <exception cref="ArgumentException">Thrown if capital is invalid, null, empty or whitespace.</exception>
        public async Task<CountryModel> GetCountryInfoByCapitalAsync(string capitalName)
        {
            if (string.IsNullOrWhiteSpace(capitalName))
            {
                throw new ArgumentException("Capital name is null, empty or whitespace");
            }

            try
            {
                string request = $"{targetedApi}capital/{capitalName}?fields=name,capital,area,population,flags,currencies,region";
                string jsonData = await _apirequester.GetJsonFromApiAsync(request);
                CountryModel output = await ConvertJsonIntoCountryModelAsync(jsonData);

                return output;
            }
            catch (JsonException ex){
                throw new ArgumentException(ex.Message);
            }
        }

        /// <summary>
        /// Converts provided JSON form REST Countries v3.1 to the CountryModel object.
        /// </summary>
        /// <param name="json">JSON to convert</param>
        /// <returns>CountryModel from specified JSON</returns>
        /// <exception cref="JsonException">Thrown if any exceptions occured in the process of converting.</exception>
        private static async Task<CountryModel> ConvertJsonIntoCountryModelAsync(string json)
        {
            try
            {
                JsonDocument document;
                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                {
                    document = await JsonDocument.ParseAsync(stream);
                }

                JsonElement rootElement;

                try
                {
                    rootElement = document.RootElement.EnumerateArray().FirstOrDefault();
                }
                catch
                {
                    rootElement = document.RootElement;
                }

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
