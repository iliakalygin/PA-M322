using Newtonsoft.Json;
using JetStreamServiceApp.Models;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Net.Http.Headers;

namespace JetStreamServiceApp.Repositories
{
    internal class Api
    {
        private static HttpClient client = new HttpClient();

        private static string? _jwtToken;

        static Api()
        {
            client.BaseAddress = new Uri("http://localhost:5241/");
        }

        public static void SetJwtToken(string token)
        {
            _jwtToken = token;
        }

        private static void AddAuthorizationHeader(HttpRequestMessage request)
        {
            if (!string.IsNullOrEmpty(_jwtToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _jwtToken);
            }
        }

        public static async Task<string> LoginAsync(string username, string password)
        {
            var loginModel = new AuthenticateUser { Username = username, Password = password };
            var json = JsonConvert.SerializeObject(loginModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"http://localhost:5241/api/Account/login", content);
            response.EnsureSuccessStatusCode();

            var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(await response.Content.ReadAsStringAsync());

            return tokenResponse.Token;
        }

        // GET alles
        public static async Task<IEnumerable<Order>?> GetOrder()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5241/Order");
            AddAuthorizationHeader(request);

            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Error Http Request");

            var result = JsonConvert.DeserializeObject<List<Order>>(await response.Content.ReadAsStringAsync());

            return result;
        }

        // GET by Id
        public static async Task<Order?> GetResourceById(string resourceUrl, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{resourceUrl}/{id}");
            AddAuthorizationHeader(request);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Order>(content);
        }

        // DELETE by Id
        public static async Task DeleteResourceById(string resourceUrl, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{resourceUrl}/{id}");
            AddAuthorizationHeader(request);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        // PUT by Id
        public static async Task UpdateResourceById(string resourceUrl, int id, Order updatedOrder)
        {
            var json = JsonConvert.SerializeObject(updatedOrder);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Put, $"{resourceUrl}/{id}");
            request.Content = content;
            AddAuthorizationHeader(request);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    }
}
