using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LuxeLoft.Server.Data.Models.Products
{
    public class Product
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }

        [Required]
        [JsonProperty("price")]
        public double Price { get; set; }

        [Required]
        [JsonProperty("category")]
        public string Category { get; set; }

        [Required]
        [JsonProperty("description")]
        public string Description { get; set; }

        [Required]
        [JsonProperty("image")]
        public string Image { get; set; }

        [Required]
        [JsonProperty("rating")]
        public ProductRatings Ratings { get; set; }
    }
}
