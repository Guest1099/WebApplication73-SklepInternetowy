using Domain.Models;
using Domain.ViewModels.Colors;

namespace Data.Repos.Abs
{
    public interface IColorsRepository
    {
        Task<List<Color>> GetAll();
        Task<Color> Get(string id);
        Task<CreateColorViewModel> Create(CreateColorViewModel model);
        Task<EditColorViewModel> Update(EditColorViewModel model);
        Task<bool> Delete(string id);
    }
}
