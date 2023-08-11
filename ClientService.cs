using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RazorPageGenerator
{
    public class ClientService<T> : IClientService<T> where T : class, new()
    {
        public async Task<IEnumerable<T>> GetAll(string endPoint)
        {
            HttpClient client = new HttpClient();
            string responseBody = "";

            try
            {
                using HttpResponseMessage response = await client.GetAsync(endPoint);
                response.EnsureSuccessStatusCode();

                responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(responseBody);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return new List<T> { };
        }
    }
}