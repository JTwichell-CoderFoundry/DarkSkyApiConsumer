using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace DarkSkyApiConsumer.Services
{
    public class DarkSkyService
    {
        public static async Task<string> getDataFromService(string queryString)
        {
       
            var client = new HttpClient();
            string json = "";

            try
            {
                var response = await client.GetAsync(queryString).ConfigureAwait(false);
                if (response != null)
                {
                    json = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                Console.WriteLine(error);
            }
            return json;
        }

    }
}