using Domain.Models;
using Domain.ViewModels.Clients;

namespace Data.Repos.Abs
{
    public interface IClientsRepository
    {
        Task<List<Client>> GetAll();
        Task<Client> Get(string id);
        Task<CreateClientViewModel> Create(CreateClientViewModel model);
        Task<EditClientViewModel> Update(EditClientViewModel model);
        Task<bool> Delete(string id);
    }
}
