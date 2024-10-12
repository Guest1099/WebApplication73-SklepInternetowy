using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.SizesProduct
{
    public class CreateEditSizeProductViewModel
    {
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string ProductId { get; set; }



        public bool Success { get; set; }
        public string? Result { get; set; }
    }
}
