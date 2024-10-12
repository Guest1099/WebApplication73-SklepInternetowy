using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class ApplicationUser : IdentityUser<string>
    {

        public int IloscZalogowan { get; set; }
        public string? DataOstatniegoZalogowania { get; set; }



        public string? DaneOsoboweId { get; set; }
        public DaneOsobowe? DaneOsobowe { get; set; }





        public List<Order>? Orders { get; set; }
        public List<Favourite>? Favourites { get; set; }
        //public List<SendMessage>? SendMessages { get; set; }
        //public List<ReceiveMessage>? ReceiveMessages { get; set; }
        public List<Like>? Likes { get; set; }
        public List<LoggingError>? LoggingErrors { get; set; }
    }
}
