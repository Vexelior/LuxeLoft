using System.ComponentModel.DataAnnotations.Schema;

namespace LuxeLoft.Server.Data.Models.Identity
{    
    /// <summary>
    /// Model for login.
    /// </summary>
    [NotMapped]
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
