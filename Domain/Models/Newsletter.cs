using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Newsletter
    {
        [Key]
        public string NewsletterId { get; set; }
        public string Email { get; set; }

    }
}
