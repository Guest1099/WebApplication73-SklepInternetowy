using Domain.Models;
using Domain.ViewModels.Subcategories;

namespace Data.Repos.Abs
{
    public interface ISubcategoriesRepository
    {
        Task<List<Subcategory>> GetAll();
        Task<Subcategory> Get(string id);
        Task<CreateSubcategoryViewModel> Create(CreateSubcategoryViewModel model);
        Task<EditSubcategoryViewModel> Update(EditSubcategoryViewModel model);
        Task<bool> Delete(string id);
    }
}
