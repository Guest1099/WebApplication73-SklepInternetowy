using Domain.Models;
using Domain.ViewModels.Newsletters;

namespace Data.Repos.Abs
{
    public interface INewsletterRepository
    {
        Task<List<Newsletter>> GetAll();
        Task<Newsletter> Get(string id);
        Task<CreateNewsletterViewModel> Create(CreateNewsletterViewModel model);
        Task<bool> Delete(string id);
    }
}
