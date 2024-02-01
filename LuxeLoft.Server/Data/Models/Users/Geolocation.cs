using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuxeLoft.Server.Data.Models.Users
{
    [NotMapped]
    public class Geolocation
    {
        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("long")]
        public string Long { get; set; }
    }
}