﻿using Data.Repos.Abs;

namespace Data
{
    public interface IUnityOfWork
    {
        ICategoriesRepository CategoriesRepository { get; set; }
        IClientsRepository ClientsRepository { get; set; }
        IColorsProductRepository ColorsProductRepository { get; set; }
        IColorsRepository ColorsRepository { get; set; }
        IFavouritesRepository FavouritesRepository { get; set; }
        //ILikesRepository FavouritesRepository { get; set; }
        IMarkiRepository MarkiRepository { get; set; }
        INewsletterRepository NewsletterRepository { get; set; }
        IOrdersRepository OrdersRepository { get; set; }
        IPhotosProductRepository PhotosProductRepository { get; set; }
        IProductsRepository ProductsRepository { get; set; }
        IReceiveMessagesRepository ReceiveMessagesRepository { get; set; }
        ISendMessagesRepository SendMessagesRepository { get; set; }
        ISizesProductRepository SizesProductRepository { get; set; }
        ISizesRepository SizesRepository { get; set; }
        ISubcategoriesRepository SubcategoriesRepository { get; set; }
        ISubsubcategoriesRepository SubsubcategoriesRepository { get; set; }


        Task SaveChangesAsync();
    }
}
