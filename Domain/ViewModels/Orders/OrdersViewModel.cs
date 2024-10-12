using Domain.Models;

namespace Domain.ViewModels.Orders
{
    public class OrdersViewModel : BaseViewModel<Order>
    {
        public List<Order> Orders { get; set; }
    }
}
