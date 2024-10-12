using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.Subsubcategories
{
    public class CreateEditSubsubcategoryViewModel
    {
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string FullName { get; set; }


        public int Kolejnosc { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string CategoryId { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string SubcategoryId { get; set; }



        public bool Success { get; set; }
        public string? Result { get; set; }
    }
}
