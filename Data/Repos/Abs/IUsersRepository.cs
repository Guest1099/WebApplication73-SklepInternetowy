using Domain.Models;
using Domain.ViewModels.Users;

namespace Data.Repos.Abs
{
    public interface IUsersRepository
    {
        Task<List<ApplicationUser>> GetAll();
        Task<ApplicationUser> Get(string id);
        Task<CreateUserViewModel> Create(CreateUserViewModel model, string password);
        Task<EditUserViewModel> Update(EditUserViewModel model);
        Task<bool> Delete(string id);
    }
}
