using Domain.Models;

namespace Domain.ViewModels.Users
{
    public class EditUserViewModel : CreateEditUserViewModel
    {
        public ApplicationUser? User { get; set; }
        public List<PhotoDaneOsobowe>? PhotosDaneOsobowe { get; set; }


        public bool IsExists { get; set; }
    }
}
