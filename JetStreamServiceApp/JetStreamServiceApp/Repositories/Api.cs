using Newtonsoft.Json;
using JetStreamServiceApp.Models;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JetStreamServiceApp.Repositories
{
    internal class Api
    {
        private static HttpClient client = new HttpClient();
        public static async Task<IEnumerable<Order>?> GetOrder()
        {


            var request = new HttpRequestMessage(HttpMethod.Get, AppSettings.Instance.OrdersUrl);
            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Error Http Request");

            var result = JsonConvert.DeserializeObject<List<Order>>(await response.Content.ReadAsStringAsync());

            return result;
        }

        public static async Task<Order?> GetResourceById(string resourceUrl, int id)
        {
            var response = await client.GetAsync($"{resourceUrl}/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Order>(content);
        }


        public static async Task DeleteResourceById(string resourceUrl, int id)
        {
            var response = await client.DeleteAsync($"{resourceUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
