using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.Newsletters
{
    public class CreateEditNewsletterViewModel
    {

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Email { get; set; }



        public bool Success { get; set; }
        public string? Result { get; set; }
    }
}
