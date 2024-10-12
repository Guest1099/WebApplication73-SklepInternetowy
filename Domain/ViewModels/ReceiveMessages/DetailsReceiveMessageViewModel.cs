using Domain.Models;

namespace Domain.ViewModels.ReceiveMessages
{
    public class DetailsReceiveMessageViewModel
    {
        public ApplicationUser FromUser { get; set; }
        public ReceiveMessage ReceiveMessage { get; set; }
    }
}
