using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.Subcategories
{
    public class CreateEditSubcategoryViewModel
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
        public Category? Category { get; set; }



        public bool Success { get; set; }
        public string? Result { get; set; }
    }
}
