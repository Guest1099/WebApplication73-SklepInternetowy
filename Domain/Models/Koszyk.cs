namespace Domain.Models
{
    /// <summary>
    /// Dane do przechowywania tymczasowego
    /// </summary>
    public class Koszyk
    {
        //[Key]
        public string KoszykId { get; set; }
        public int Ilosc { get; set; }
        public double Cena { get; set; }


        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }


        public string ClientId { get; set; }
        public Client Client { get; set; }


        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
