using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.Marki
{
    public class CreateEditMarkaViewModel
    {
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Name { get; set; }



        public bool Success { get; set; }
        public string? Result { get; set; }
    }
}
