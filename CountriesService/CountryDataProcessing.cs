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

        public CountryModel GetCountryInfoByCode(string countryCode)
        {
            throw new NotImplementedException();
        }

        public CountryModel GetCountryInfoByName(string countryName)
        {
            throw new NotImplementedException();
        }

        public CountryModel GetCountryInfoByCapital(string capitalName)
        {
            throw new NotImplementedException();
        }

        private static CountryModel ConvertJsonIntoCountryModel(JsonDocument json)
        {
            throw new NotImplementedException();
        }
    }
}
