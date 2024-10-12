using Domain.Models;
using Domain.ViewModels.Marki;

namespace Data.Repos.Abs
{
    public interface IMarkiRepository
    {
        Task<List<Marka>> GetAll();
        Task<Marka> Get(string id);
        Task<CreateMarkaViewModel> Create(CreateMarkaViewModel model);
        Task<EditMarkaViewModel> Update(EditMarkaViewModel model);
        Task<bool> Delete(string id);
    }
}
