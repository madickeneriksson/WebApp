using System.ComponentModel.DataAnnotations;
using WebApp.Models;
using WebApp.Models.Entities;

namespace WebApp.ViewModels
{
    public class ContactformViewModel
    {
        public int Id { get; set; }

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
       
        [Display(Name = "Telefonnummer")]
        public string PhoneNumber { get; set; } = null!;

        [Display(Name = "Company")]
        public string? Company { get; set; }

        [Required(ErrorMessage = "Du måste ange ett meddelande")]
        [Display(Name = "Meddelande")]
        public string Message { get; set; } = null!;

        public static implicit operator ContactFormEntity(ContactformViewModel contactformViewModel)
        {
            return new ContactFormEntity
            {
                Id = contactformViewModel.Id
                , Name = contactformViewModel.Name,
                Email = contactformViewModel.Email,
                PhoneNumber = contactformViewModel.PhoneNumber,
                Company = contactformViewModel.Company,
                Message = contactformViewModel.Message,
            };

        }
    }
}
