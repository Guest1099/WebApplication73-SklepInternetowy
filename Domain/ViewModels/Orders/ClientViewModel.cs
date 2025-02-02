﻿using Domain.Models.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.Orders
{
    public class ClientViewModel
    {
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Imie { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Nazwisko { get; set; }


        [Required(ErrorMessage = "*")]
        public byte[] Photo { get; set; }


        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^(\d{9}|\d{3}\s\d{3}\s\d{3})$", ErrorMessage = "*")]
        public string Telefon { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Ulica { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string NumerUlicy { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Miejscowosc { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Kraj { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string KodPocztowy { get; set; }


        [Required(ErrorMessage = "*")]
        public string DataUrodzenia { get; set; }


        [Required(ErrorMessage = "*")]
        public Plec Plec { get; set; }


        [Required(ErrorMessage = "*")]
        public bool Newsletter { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "*")]
        public RodzajOsoby RodzajOsoby { get; set; }


        public bool HasAccount { get; set; }

        public List<IFormFile> Files { get; set; }

        public bool Success { get; set; }
        public string? Result { get; set; }
    }
}
