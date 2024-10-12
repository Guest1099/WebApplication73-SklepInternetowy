using Domain.Models;
using Domain.ViewModels.Orders;

namespace Data.Repos.Abs
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetAll();
        Task<List<Order>> GetAllZamowieniaNiezrealizowane();
        Task<Order> Get(string id);
        Task<CreateOrderViewModel> Create(CreateOrderViewModel model);
        Task<EditOrderViewModel> Update(EditOrderViewModel model);
        Task<bool> Delete(string id);
    }
}
