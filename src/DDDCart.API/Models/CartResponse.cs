using System.Text.Json.Serialization;

namespace DDDCart.API.Models
{
    public class CartResponse
    {
        [JsonPropertyName("itemCount")]
        public int ItemCount { get; set; }

        [JsonPropertyName("customerId")]
        public string? CustomerId { get; set; }
    }
}
