using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class SizeProduct
    {
        [Key]
        public string SizeProductId { get; set; }
        public string Name { get; set; }



        public string? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
