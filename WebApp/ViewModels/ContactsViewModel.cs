﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApp.ViewModels
{
    public class ContactsViewModel
    {
        [Required(ErrorMessage = "Du måste ange ett förnamn")]
        [RegularExpression(@"^[A-Za-zåäöÅÄÖ]+(?:\s[A-Za-zåäöÅÄÖ]+)*$", ErrorMessage = "Du måste ange ett giltigt namn")]
        [Display(Name = "Ditt namn")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Du måste ange en e-postadress")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Du måste ange en giltig e-postadress")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Du måste ange ett telefonnummer")]
        [RegularExpression(@"^(?:(?:\+|00)46|0) ?(?:[1-9]\d{1,2}-\d{2} ?\d{2}|\d{2}-\d{7})$", ErrorMessage = "Du måste ange ett giltigt telefonnummer")]
        [Display(Name = "Telefonnummer")]
        public string PhoneNumber { get; set; } = null!;

        [Display(Name = "Company")]
        public string? Company { get; set; }

        [Required(ErrorMessage = "Du måste ange ett meddelande")]
        [Display(Name = "Meddelande")]
        public string Message { get; set; } = null!;
    }
}