using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CountriesService.ApiDataAccess
{
    /// <summary>
    /// Defines neccesary methods for classes with API requesting functionality.
    /// </summary>
    public interface IApiRequest
    {
        /// <summary>
        /// Defines asynchronous method to retreive data in JSON format from the API.
        /// </summary>
        /// <param name="apiEndpoint">Targeted resource in the API to retreive data from.</param>
        /// <returns>Raw data in JSON format.</returns>
        public Task<string> GetJsonFromApiAsync(string apiEndpoint);
    }
}
