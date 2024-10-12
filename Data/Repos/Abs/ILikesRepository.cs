using Domain.Models;
using Domain.ViewModels.Likes;

namespace Data.Repos.Abs
{
    public interface ILikesRepository
    {
        Task<List<Like>> GetAll();
        Task<Like> Get(string id);
        Task<CreateLikeViewModel> Create(CreateLikeViewModel model);
        Task<EditLikeViewModel> Update(EditLikeViewModel model);
        Task<bool> Delete(string id);
    }
}
