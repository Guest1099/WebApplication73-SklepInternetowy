﻿using Application.Services.Abs;
using Data;
using Domain.Models;
using Domain.ViewModels.Colors;

namespace Application.Services
{
    public class ColorsService : IColorsService
    {
        private readonly IUnityOfWork _unityOfWork;

        public ColorsService(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<List<Color>> GetAll()
        {
            return await _unityOfWork.ColorsRepository.GetAll();
        }

        public async Task<Color> Get(string id)
        {
            return await _unityOfWork.ColorsRepository.Get(id);
        }

        public async Task<CreateColorViewModel> Create(CreateColorViewModel model)
        {
            return await _unityOfWork.ColorsRepository.Create(model);
        }


        public async Task<EditColorViewModel> Update(EditColorViewModel model)
        {
            return await _unityOfWork.ColorsRepository.Update(model);
        }


        public async Task<bool> Delete(string id)
        {
            return await _unityOfWork.ColorsRepository.Delete(id);
        }

    }
}
