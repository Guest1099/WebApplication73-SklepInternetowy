using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Size
    {
        [Key]
        public string SizeId { get; set; }
        public string Name { get; set; }
    }
}
