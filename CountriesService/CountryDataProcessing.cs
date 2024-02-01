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
            throw new NotImplementedException();
        }
    }
}
