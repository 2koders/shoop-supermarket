using System.Collections.Generic;
using Newtonsoft.Json;
using shoopsupermarket.Data;

namespace shoopsupermarket.Models
{
    public class Item
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public double Total { get; set; }
    }

    public class PaymentIntentCreateRequest
    {
        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }
}