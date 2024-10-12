using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.Payments
{
    public class PaymentsViewModel
    {
        public string OrderId { get; set; }

        [Required(ErrorMessage = "Jedna z opcji musi być wybrana")]
        public string SposobPlatnosci { get; set; }


        [Required(ErrorMessage = "Jedna z opcji musi być wybrana")]
        public string SposobWysylki { get; set; }
    }
}
