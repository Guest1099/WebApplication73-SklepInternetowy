namespace Domain.Models
{
    /// <summary>
    /// Dane do przechowywania tymczasowego
    /// </summary>
    public class KoszykItem
    {
        public string KoszykItemId { get; set; }
        public int Ilosc { get; set; }
        public double Suma { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
