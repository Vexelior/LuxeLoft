using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuxeLoft.Server.Data.Models.Carts
{
    public class CartProducts
    {
        [Key]
        public int Id { get; set; }

        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
