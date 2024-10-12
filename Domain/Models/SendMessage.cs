using Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class SendMessage
    {
        [Key]
        public string SendMessageId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DataNadania { get; set; }
        public MessageStatus MessageStatus { get; set; }


        public string? FromUserId { get; set; }
        public ApplicationUser? FromUser { get; set; }


        public string? ToUserId { get; set; }
        public ApplicationUser? ToUser { get; set; }
    }
}
