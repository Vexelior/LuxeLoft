using System.ComponentModel.DataAnnotations;

namespace LuxeLoft.Server.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public List<Product> Products { get; set; }
    }
}
