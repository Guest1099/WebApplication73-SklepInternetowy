using Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class DaneOsobowe
    {
        [Key]
        public string? DaneOsoboweId { get; set; }


        // dane personalne

        [Required(ErrorMessage = "* Pole wymagane")]
        public string? Imie { get; set; }


        [Required(ErrorMessage = "* Pole wymagane")]
        public string? Nazwisko { get; set; }


        [Required(ErrorMessage = "* Pole wymagane")]
        public string? Ulica { get; set; }


        [Required(ErrorMessage = "* Pole wymagane")]
        public string? NumerUlicy { get; set; }


        [Required(ErrorMessage = "* Pole wymagane")]
        public string? Miejscowosc { get; set; }


        [Required(ErrorMessage = "* Pole wymagane")]
        public string? KodPocztowy { get; set; }


        [Required(ErrorMessage = "* Pole wymagane")]
        public string? Wojewodztwo { get; set; }


        [Required(ErrorMessage = "* Pole wymagane")]
        public string? Kraj { get; set; }


        [Required(ErrorMessage = "* Pole wymagane")]
        public string? Pesel { get; set; }


        [Required(ErrorMessage = "* Pole wymagane")]
        [DataType(DataType.Date)]
        public string? DataUrodzenia { get; set; }


        [Required(ErrorMessage = "* Pole wymagane")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "* Pole wymagane")]
        public string? Telefon { get; set; }
        public Plec Plec { get; set; }
        public RodzajOsoby RodzajOsoby { get; set; }
        public bool Newsletter { get; set; }



        // dane firmy
        public string? Firma_Nazwa { get; set; }
        public string? Firma_NIP { get; set; }
        public string? Firma_Regon { get; set; }
        public string? Firma_Ulica { get; set; }
        public string? Firma_NumerUlicy { get; set; }
        public string? Firma_Miejscowosc { get; set; }
        public string? Firma_KodPocztowy { get; set; }
        public string? Firma_Wojewodztwo { get; set; }
        public string? Firma_Kraj { get; set; }



        public string? DataDodania { get; set; }




        public List<ApplicationUser>? Users { get; set; }
        public List<Client>? Clients { get; set; }
        public List<PhotoDaneOsobowe>? PhotosDaneOsobowe { get; set; }

    }
}
