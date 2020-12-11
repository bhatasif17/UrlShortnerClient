using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace client.URLShortner
{
    public interface IApiHelper
    {
        Task<string> POST<T>(T payload, string resource);
        Task<string> GET(string resource);
    }
    public class ApiHelper : IApiHelper
    {
        public async Task<string> POST<T>(T payload, string resource)
        {
            try
            {
                var client = new RestClient("https://urlshortner20201211221431.azurewebsites.net/");
                var request = new RestRequest($"{resource}")
                    .AddJsonBody(payload);

                request.Method = Method.POST;
                request.AddHeader("Content-Type", "application/json");

                var response = await client.ExecutePostAsync(request);
                return JsonConvert.DeserializeObject<string>(response.Content);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<string> GET(string id)
        {
            try
            {
                var client = new RestClient("https://urlshortner20201211221431.azurewebsites.net/");
                var request = new RestRequest($"{id}");

                request.Method = Method.GET;
                request.AddHeader("Accept", "text/xml");

                var response = await client.ExecuteGetAsync(request);
                return JsonConvert.DeserializeObject<string>(response.Content);
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}