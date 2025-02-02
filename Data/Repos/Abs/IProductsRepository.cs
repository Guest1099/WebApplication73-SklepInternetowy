﻿using Domain.Models;
using Domain.ViewModels.Products;

namespace Data.Repos.Abs
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> Get(string id);
        Task<CreateProductViewModel> Create(CreateProductViewModel model);
        Task<EditProductViewModel> Update(EditProductViewModel model);
        Task<bool> Delete(string id);
    }
}
