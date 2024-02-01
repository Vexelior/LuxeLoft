using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LuxeLoft.Server.Data.Models.Users
{
    public class User
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        public Name Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
        public Address Address { get; set; }

        [JsonProperty("__v")]
        public int __v { get; set; }

        // Additional properties for direct access to nested fields
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Zipcode { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
