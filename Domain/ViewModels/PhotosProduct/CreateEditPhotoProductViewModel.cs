using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.PhotosProduct
{
    public class CreateEditPhotoClientViewModel
    {
        public string PhotoProductId { get; set; }
        public byte[] PhotoData { get; set; }


        [Required]
        [DataType(DataType.Text)]
        public string ProductId { get; set; }


        public bool Success { get; set; }
        public string? Result { get; set; }
    }
}
