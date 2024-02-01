using System.ComponentModel.DataAnnotations;

namespace LuxeLoft.Server.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Zipcode { get; set; }
        public string GeoLat { get; set; }
        public string GeoLong { get; set; }
        public string Phone { get; set; }
    }
}
