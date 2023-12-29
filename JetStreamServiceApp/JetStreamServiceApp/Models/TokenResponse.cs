using Newtonsoft.Json;

namespace JetStreamServiceApp.Models
{
    class TokenResponse
    {
        [JsonProperty("token")]
        public string? Token { get; set; }
    }
}
