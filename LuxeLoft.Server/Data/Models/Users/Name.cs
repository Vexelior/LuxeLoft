using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuxeLoft.Server.Data.Models.Users
{
    [NotMapped]
    public class Name
    {
        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }
    }
}