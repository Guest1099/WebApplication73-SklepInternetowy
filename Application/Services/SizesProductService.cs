﻿using Application.Services.Abs;
using Data;
using Domain.Models;
using Domain.ViewModels.SizesProduct;

namespace Application.Services
{
    public class SizesProductService : ISizesProductService
    {
        private readonly IUnityOfWork _unityOfWork;

        public SizesProductService(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<List<SizeProduct>> GetAll()
        {
            return await _unityOfWork.SizesProductRepository.GetAll();
        }

        public async Task<SizeProduct> Get(string id)
        {
            return await _unityOfWork.SizesProductRepository.Get(id);
        }

        public async Task<CreateSizeProductViewModel> Create(CreateSizeProductViewModel model)
        {
            return await _unityOfWork.SizesProductRepository.Create(model);
        }


        public async Task<EditSizeProductViewModel> Update(EditSizeProductViewModel model)
        {
            return await _unityOfWork.SizesProductRepository.Update(model);
        }


        public async Task<bool> Delete(string id)
        {
            return await _unityOfWork.SizesProductRepository.Delete(id);
        }

    }
}
