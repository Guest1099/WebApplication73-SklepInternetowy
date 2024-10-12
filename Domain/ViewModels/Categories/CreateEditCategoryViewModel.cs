using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.Categories
{
    public class CreateEditCategoryViewModel
    {
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string FullName { get; set; }


        public bool Success { get; set; }
        public string? Result { get; set; }
    }
}
