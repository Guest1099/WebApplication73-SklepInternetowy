using Domain.Models;
using Domain.ViewModels.Sizes;

namespace Data.Repos.Abs
{
    public interface ISizesRepository
    {
        Task<List<Size>> GetAll();
        Task<Size> Get(string id);
        Task<CreateSizeViewModel> Create(CreateSizeViewModel model);
        Task<EditSizeViewModel> Update(EditSizeViewModel model);
        Task<bool> Delete(string id);
    }
}
