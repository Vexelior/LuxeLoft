using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace LuxeLoft.Server.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserId { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public List<Product> Products { get; set; }
    }
}
