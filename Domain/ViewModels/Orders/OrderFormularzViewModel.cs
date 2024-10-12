using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.Orders
{
    public class OrderFormularzViewModel
    {
        [Required(ErrorMessage = "Jedna z opcji musi być wybrana")]
        public string RodzajTransakcji { get; set; }


        public string? Result { get; set; }
    }
}
