﻿using Domain.Models;
using Domain.ViewModels.PhotosProduct;

namespace Data.Repos.Abs
{
    public interface IPhotosProductRepository
    {
        Task<List<PhotoProduct>> GetAll();
        Task<PhotoProduct> Get(string id);
        Task<CreatePhotoClientViewModel> Create(CreatePhotoClientViewModel model);
        Task<EditPhotoClientViewModel> Update(EditPhotoClientViewModel model);
        Task<bool> Delete(string id);
        Task<bool> DeletePhotoProductByProductId(string productId, string photoProductId);
    }
}
