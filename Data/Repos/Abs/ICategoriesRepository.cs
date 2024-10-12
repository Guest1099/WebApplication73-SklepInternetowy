using Domain.Models;
using Domain.ViewModels.Categories;

namespace Data.Repos.Abs
{
    public interface ICategoriesRepository
    {
        Task<List<Category>> GetAll();
        Task<Category> Get(string id);
        Task<CreateCategoryViewModel> Create(CreateCategoryViewModel model);
        Task<EditCategoryViewModel> Update(EditCategoryViewModel model);
        Task<bool> Delete(string id);
    }
}
