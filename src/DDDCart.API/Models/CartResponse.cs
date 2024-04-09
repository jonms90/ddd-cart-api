using System.Text.Json.Serialization;

namespace DDDCart.API.Models
{
    public class CartResponse
    {
        [JsonPropertyName("itemCount")]
        public int ItemCount { get; set; } 
        public string CustomerId { get; set; }
    }
}
