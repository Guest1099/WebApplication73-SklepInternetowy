using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.Colors
{
    public class CreateEditColorViewModel
    {
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Name { get; set; }



        public bool Success { get; set; }
        public string? Result { get; set; }
    }
}
