using Domain.Models;
using Domain.ViewModels.Favourites;

namespace Data.Repos.Abs
{
    public interface IFavouritesRepository
    {
        Task<List<Favourite>> GetAll();
        Task<Favourite> Get(string id);
        Task<CreateFavouriteViewModel> Create(CreateFavouriteViewModel model);
        Task<bool> Delete(string id);
    }
}
