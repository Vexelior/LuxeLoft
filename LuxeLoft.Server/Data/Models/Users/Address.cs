using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuxeLoft.Server.Data.Models.Users
{
    [NotMapped]
    public class Address
    {
        public Geolocation Geolocation { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }
    }
}