using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.Favourites
{
    public class CreateFavouriteViewModel
    {
        public string FavouriteId { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string ProductId { get; set; }



        public bool Success { get; set; }
        public string? Result { get; set; }
    }
}
