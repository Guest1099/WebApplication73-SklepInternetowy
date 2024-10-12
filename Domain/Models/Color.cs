using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Color
    {
        [Key]
        public string ColorId { get; set; }
        public string Name { get; set; }

    }
}
