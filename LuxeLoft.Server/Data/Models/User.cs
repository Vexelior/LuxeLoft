using System.ComponentModel.DataAnnotations;

namespace LuxeLoft.Server.Data.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(50)]
        public string Street { get; set; }

        [Required]
        [MaxLength(50)]
        public string Number { get; set; }

        [Required]
        [MaxLength(50)]
        public string Zipcode { get; set; }

        [Required]
        [MaxLength(50)]
        public string GeoLat { get; set; }

        [Required]
        [MaxLength(50)]
        public string GeoLong { get; set; }

        [Required]
        [MaxLength(50)]
        [Phone]
        public string Phone { get; set; }
    }
}
