using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace LuxeLoft.Server.Data.Models.Carts
{
    public class Cart
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required]
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [Required]
        [JsonProperty("products")]
        public List<CartProducts> Products { get; set; }

        [JsonProperty("__v")]
        public int __v { get; set; }
    }
}
