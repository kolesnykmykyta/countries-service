using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CountriesService.ApiDataAccess
{
    /// <summary>
    /// Class that provides functionality to receive data from the API.
    /// </summary>
    public class ApiRequest: IApiRequest
    {
        /// <summary>
        /// Method to retreive data from the API asynchronously.
        /// </summary>
        /// <param name="apiEndpoint">Targeted resource in the API to retreive data from.</param>
        /// <returns>Raw data in JSON format.</returns>
        public async Task<string> GetJsonFromApiAsync(string apiEndpoint)
        {
            string output;

            using (HttpClient client = new HttpClient())
            {
                output = await client.GetStringAsync(apiEndpoint);
            }

            return output;
        }
    }
}
