using Application.Services.Abs;
using Data;
using Domain.Models;
using Domain.ViewModels.Newsletters;

namespace Application.Services
{
    public class NewsletterService : INewsletterService
    {
        private readonly IUnityOfWork _unityOfWork;

        public NewsletterService(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<List<Newsletter>> GetAll()
        {
            return await _unityOfWork.NewsletterRepository.GetAll();
        }

        public async Task<Newsletter> Get(string id)
        {
            return await _unityOfWork.NewsletterRepository.Get(id);
        }

        public async Task<CreateNewsletterViewModel> Create(CreateNewsletterViewModel model)
        {
            return await _unityOfWork.NewsletterRepository.Create(model);
        }

        public async Task<bool> Delete(string id)
        {
            return await _unityOfWork.CategoriesRepository.Delete(id);
        }

    }
}
