﻿using Domain.Models;

namespace Domain.ViewModels.Orders
{
    public class CreateEditOrderViewModel : Order
    {
        /*[Required(ErrorMessage = "*")] 
        public int Ilosc { get; set; }


        [Required(ErrorMessage = "*")]
        public double Suma { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string SposobPlatnosci { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string SposobWysylki { get; set; }



        [Required(ErrorMessage = "*")]
        public StatusZamowienia StatusZamowienia { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string OsobaRealizujacaId { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string ClientId { get; set; }*/



        public bool Success { get; set; }
        public string? Result { get; set; }
    }
}
