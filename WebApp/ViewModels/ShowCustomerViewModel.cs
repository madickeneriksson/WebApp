﻿using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class ShowCustomerViewModel
    {

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string StreetName { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string City { get; set; } = null!;

        public string? Mobile { get; set; }

        public string? Company { get; set; }

        public string Email { get; set; } = null!;

        public IFormFile? ImageFile { get; set; }

    }
}
