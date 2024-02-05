﻿using CountriesService.ApiDataAccess;
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
