using System.Text.Json.Serialization;

namespace DDDCart.API.Models
{
    public class AddProductResponse
    {
        [JsonPropertyName("itemCount")]
        public int ItemCount { get; set; }
    }
}
