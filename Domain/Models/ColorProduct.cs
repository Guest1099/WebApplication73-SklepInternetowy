using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class ColorProduct
    {
        [Key]
        public string ColorProductId { get; set; }
        public string Name { get; set; }


        public string? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
