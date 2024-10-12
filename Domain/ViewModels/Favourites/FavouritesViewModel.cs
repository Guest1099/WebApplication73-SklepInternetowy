using Domain.Models;

namespace Domain.ViewModels.Favourites
{
    public class FavouritesViewModel : BaseViewModel<Favourite>
    {
        public List<Favourite> Favourites { get; set; }
    }
}
