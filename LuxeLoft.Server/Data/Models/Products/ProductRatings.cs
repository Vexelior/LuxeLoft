using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LuxeLoft.Server.Data.Models.Products
{
    public class ProductRatings
    {
        [Key]
        public int Id { get; set; }

        [JsonProperty("rate")]
        public double Rate { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}