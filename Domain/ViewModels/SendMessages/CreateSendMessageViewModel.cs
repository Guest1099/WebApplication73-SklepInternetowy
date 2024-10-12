using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.SendMessages
{
    public class CreateSendMessageViewModel
    {
        public string UserName { get; set; }
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Title { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Description { get; set; }


        public string? Result { get; set; }
    }
}
