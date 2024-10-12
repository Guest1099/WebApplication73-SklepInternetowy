using Domain.Models;
using Domain.ViewModels.Subsubcategories;

namespace Data.Repos.Abs
{
    public interface ISubsubcategoriesRepository
    {
        Task<List<Subsubcategory>> GetAll();
        Task<Subsubcategory> Get(string id);
        Task<CreateSubsubcategoryViewModel> Create(CreateSubsubcategoryViewModel model);
        Task<EditSubsubcategoryViewModel> Update(EditSubsubcategoryViewModel model);
        Task<bool> Delete(string id);
    }
}
