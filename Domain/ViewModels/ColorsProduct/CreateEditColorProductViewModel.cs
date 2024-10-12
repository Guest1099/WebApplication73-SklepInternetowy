using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.ColorsProduct
{
    public class CreateEditColorProductViewModel
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
