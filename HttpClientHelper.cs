using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;
using Newtonsoft.Json;

namespace RazorPageGenerator
{
    public class HttpClientHelper : IClientHelper
    {

        public async Task<string> GetJson(string endPoint)
        {
            HttpClient client = new HttpClient();
            string responseBody = "";

            try
            {
                using HttpResponseMessage response = await client.GetAsync(endPoint);
                response.EnsureSuccessStatusCode();

                responseBody = await response.Content.ReadAsStringAsync();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return responseBody;
        }

    }
}