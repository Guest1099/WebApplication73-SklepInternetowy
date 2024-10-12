using Data.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.Users
{
    public class CreateEditUserViewModel
    {

        public ApplicationUser User { get; set; }


        [Required(ErrorMessage = "*")]
        [MinLength(5, ErrorMessage = "Hasło musi mieć co najmniej 5 znaków")]
        [DataType(DataType.Password)]
        [PasswordRequirements]
        public string? Password { get; set; }



        public List<string> SelectedRoles { get; set; } = new List<string>();
        public List<IFormFile>? Files { get; set; }
        public bool Success { get; set; }
        public string? Result { get; set; }
    }
}
