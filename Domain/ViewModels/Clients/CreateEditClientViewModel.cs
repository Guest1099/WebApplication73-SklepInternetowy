using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Domain.ViewModels.Clients
{
    public class CreateEditClientViewModel
    {
        public Client? Client { get; set; }


        public List<IFormFile>? Files { get; set; }

        public bool Success { get; set; }
        public string? Result { get; set; }
    }
}
