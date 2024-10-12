using Domain.Models;
using Domain.ViewModels.SizesProduct;

namespace Data.Repos.Abs
{
    public interface ISizesProductRepository
    {
        Task<List<SizeProduct>> GetAll();
        Task<SizeProduct> Get(string id);
        Task<CreateSizeProductViewModel> Create(CreateSizeProductViewModel model);
        Task<EditSizeProductViewModel> Update(EditSizeProductViewModel model);
        Task<bool> Delete(string id);
    }
}
