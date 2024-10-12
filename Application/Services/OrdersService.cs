using Application.Services.Abs;
using Data;
using Domain.Models;
using Domain.Models.Enums;
using Domain.ViewModels.Orders;

namespace Application.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IUnityOfWork _unityOfWork;

        public OrdersService(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _unityOfWork.OrdersRepository.GetAll();
        }

        public async Task<List<Order>> GetAllZamowieniaNiezrealizowane()
        {
            return (await _unityOfWork.OrdersRepository.GetAll())
                .Where(w => w.StatusZamowienia == StatusZamowienia.Niezrealizowane)
                .ToList();
        }

        public async Task<Order> Get(string id)
        {
            return await _unityOfWork.OrdersRepository.Get(id);
        }

        public async Task<CreateOrderViewModel> Create(CreateOrderViewModel model)
        {
            return await _unityOfWork.OrdersRepository.Create(model);
        }


        public async Task<EditOrderViewModel> Update(EditOrderViewModel model)
        {
            return await _unityOfWork.OrdersRepository.Update(model);
        }


        public async Task<bool> Delete(string id)
        {
            return await _unityOfWork.OrdersRepository.Delete(id);
        }

    }
}
