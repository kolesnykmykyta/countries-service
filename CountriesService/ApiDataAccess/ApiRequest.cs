using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CountriesService.ApiDataAccess
{
    public class ApiRequest: IApiRequest
    {
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
