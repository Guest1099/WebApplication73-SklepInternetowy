﻿namespace Domain.ViewModels.Account
{
    public class ConfirmEmailViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }

        public bool Result { get; set; }
    }
}
