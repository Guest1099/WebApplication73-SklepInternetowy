using Data.Services;
using Domain.ViewModels.Users;
using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.Account
{
    public class RegisterViewModel : CreateEditUserViewModel
    {

        /*[Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }*/


        [Required(ErrorMessage = "*")]
        [StringLength(100, ErrorMessage = "Hasło musi mieć co najmniej 10 znaków")]
        [DataType(DataType.Password)]
        [PasswordRequirements]
        public string Password { get; set; }


        public string DataRejestracji { get; set; }
    }
}
