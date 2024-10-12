using Domain.Models;

namespace Domain.ViewModels.Koszyk
{
    public class KoszykViewModel
    {
        public string KoszykItemId { get; set; }
        public int Ilosc { get; set; }
        public List<KoszykItem> KoszykItems { get; set; }

    }
}
