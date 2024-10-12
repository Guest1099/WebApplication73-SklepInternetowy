using Domain.Models;

namespace Domain.ViewModels.SendMessages
{
    public class DetailsSendMessageViewModel
    {
        public ApplicationUser ToUser { get; set; }
        public SendMessage SendMessage { get; set; }
    }
}
