using Domain.Models;
using Domain.ViewModels.ColorsProduct;

namespace Data.Repos.Abs
{
    public interface IColorsProductRepository
    {
        Task<List<ColorProduct>> GetAll();
        Task<ColorProduct> Get(string id);
        Task<CreateColorProductViewModel> Create(CreateColorProductViewModel model);
        Task<EditColorProductViewModel> Update(EditColorProductViewModel model);
        Task<bool> Delete(string id);
    }
}
