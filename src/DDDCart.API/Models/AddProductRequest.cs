using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DDDCart.API.Models
{
    public class AddProductRequest
    {
        [JsonPropertyName("sku")]
        [Length(11, 11)]
        [Required]
        public string Sku { get; set; }

        [JsonPropertyName("quantity")]
        [Range(-99,99)]
        [Required]
        public int Quantity { get; set; }
    }
}
