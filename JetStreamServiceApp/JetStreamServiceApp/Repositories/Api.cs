using Newtonsoft.Json;
using JetStreamServiceApp.Models;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;

namespace JetStreamServiceApp.Repositories
{
    internal class Api
    {
        private static HttpClient client = new HttpClient();

        // GET alles
        public static async Task<IEnumerable<Order>?> GetOrder()
        {


            var request = new HttpRequestMessage(HttpMethod.Get, AppSettings.Instance.OrdersUrl);
            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Error Http Request");

            var result = JsonConvert.DeserializeObject<List<Order>>(await response.Content.ReadAsStringAsync());

            return result;
        }

        // GET by Id
        public static async Task<Order?> GetResourceById(string resourceUrl, int id)
        {
            
            var response = await client.GetAsync($"{resourceUrl}/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Order>(content);

        }

        // DELETE by Id
        public static async Task DeleteResourceById(string resourceUrl, int id)
        {
            var response = await client.DeleteAsync($"{resourceUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }

        // PUT by Id
        public static async Task UpdateResourceById(string resourceUrl, int id, Order updatedOrder)
        {
            var json = JsonConvert.SerializeObject(updatedOrder);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{resourceUrl}/{id}", content);
            response.EnsureSuccessStatusCode();
        }
    }
}