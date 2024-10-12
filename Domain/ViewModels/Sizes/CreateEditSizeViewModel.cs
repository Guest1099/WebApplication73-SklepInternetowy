using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.Sizes
{
    public class CreateEditSizeViewModel
    {
        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Wartość pola musi być liczbą całkowitą lub zmiennoprzecinkową.")]
        public string Name { get; set; }


        public bool Success { get; set; }
        public string? Result { get; set; }
    }
}
