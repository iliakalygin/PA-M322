using System;
using JetStreamServiceApp.ViewModels;
using Newtonsoft.Json;

namespace JetStreamServiceApp.Models
{
    public class Order : ViewModelBase
    {
        [JsonProperty("orderID")]
        public int OrderID { get; set; }
        [JsonProperty("customerName")]
        public string? CustomerName { get; set; }
        [JsonProperty("customerEmail")]
        public string? CustomerEmail { get; set; }
        [JsonProperty("customerPhone")]
        public string? CustomerPhone { get; set; }
        [JsonProperty("priority")]
        public string? Priority { get; set; }
        [JsonProperty("serviceType")]
        public string? ServiceType { get; set; }
        [JsonProperty("createDate")]
        public DateTime CreateDate { get; set; }
        [JsonProperty("pickupDate")]
        public DateTime PickupDate { get; set; }
        [JsonProperty("status")]
        public string? Status { get; set; }
        [JsonProperty("comment")]
        public string? Comment { get; set; }

    }
}
