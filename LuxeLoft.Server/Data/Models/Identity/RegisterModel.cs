using System.ComponentModel.DataAnnotations.Schema;

namespace LuxeLoft.Server.Data.Models.Identity
{    
    /// <summary>
    /// Model for registration.
    /// </summary>
    [NotMapped]
    public class RegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
