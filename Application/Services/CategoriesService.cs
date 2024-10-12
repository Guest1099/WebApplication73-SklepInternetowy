using Application.Services.Abs;
using Data;
using Domain.Models;
using Domain.ViewModels.Categories;

namespace Application.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IUnityOfWork _unityOfWork;

        public CategoriesService(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _unityOfWork.CategoriesRepository.GetAll();
        }

        public async Task<Category> Get(string id)
        {
            return await _unityOfWork.CategoriesRepository.Get(id);
        }

        public async Task<CreateCategoryViewModel> Create(CreateCategoryViewModel model)
        {
            return await _unityOfWork.CategoriesRepository.Create(model);
        }


        public async Task<EditCategoryViewModel> Update(EditCategoryViewModel model)
        {
            return await _unityOfWork.CategoriesRepository.Update(model);
        }


        public async Task<bool> Delete(string id)
        {
            return await _unityOfWork.CategoriesRepository.Delete(id);
        }


    }

}
