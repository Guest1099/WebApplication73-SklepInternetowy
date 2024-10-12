using Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Order
    {
        [Key]
        public string OrderId { get; set; }
        public int Ilosc { get; set; }
        public double Suma { get; set; }
        public string DataZamowienia { get; set; }
        public string DataRealizacji { get; set; }
        public string SposobPlatnosci { get; set; }
        public string SposobWysylki { get; set; }
        public bool Confirmed { get; set; }
        public StatusZamowienia StatusZamowienia { get; set; }


        /*
                public string OsobaRealizujacaId { get; set; }
                public ApplicationUser? OsobaRealizujaca { get; set; }
        */


        // zamówienia składane przez użytkownika systemu
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }


        // zamówienia składane przez klienta
        public string? ClientId { get; set; }
        public Client? Client { get; set; }



        public List<OrderItem>? OrderItems { get; set; }

    }
}
