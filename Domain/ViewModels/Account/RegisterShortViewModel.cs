using Data.Services;
using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.Account
{
    public class RegisterShortViewModel
    {
        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "*")]
        [StringLength(100, ErrorMessage = "Hasło musi mieć co najmniej 10 znaków")]
        [DataType(DataType.Password)]
        [PasswordRequirements]
        public string Password { get; set; }



        public bool Success { get; set; }
        public string? Result { get; set; }
    }
}
