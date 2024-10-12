using Domain.Models;

namespace Domain.ViewModels.Orders
{
    public class OrderConfirmationViewModel
    {
        public Client Client { get; set; }
        public Order Order { get; set; }
        public List<KoszykItem> KoszykItems { get; set; }
    }
}
