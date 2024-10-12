using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Lajkowanie produktów
    /// </summary>
    public class Like
    {
        [Key]
        public string LikeId { get; set; }


        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }


        public string? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
