using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;
using WebApp.Models.Identity;

namespace WebApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Du måste ange ett förnamn")]
        [RegularExpression(@"^[A-Za-zåäöÅÄÖ]+(?:\s[A-Za-zåäöÅÄÖ]+)*$", ErrorMessage = "Du måste ange ett giltigt förnamn")]
        [Display(Name ="Förnamn")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Du måste ange ett efternamn")]
        [RegularExpression(@"^[A-Za-zåäöÅÄÖ]+(?:\s[A-Za-zåäöÅÄÖ]+)*$", ErrorMessage = "Du måste ange ett giltigt förnamn")]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Du måste ange en gatuadress")]
        [Display(Name = "Gatuadress")]
        public string StreetName { get; set; } = null!;

        [Required(ErrorMessage = "Du måste ange en postkod")]
        [Display(Name = "Postadress")]
        public string PostalCode { get; set; } = null!;

        [Required(ErrorMessage = "Du måste ange en stad")]
        [Display(Name = "Stad")]
        public string City { get; set; } = null!;

        [Display(Name = "Telefonnummer")]
        public string? Mobile { get; set; }

        [Display(Name = "Company")]
        public string? Company { get; set; }

        [Required(ErrorMessage = "Du måste ange en e-postadress")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Du måste ange en giltig e-postadress")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Du måste ange ett lösenord")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Lösenordet ska vara minst 8 tecken, innehålla en stor och liten bokstav, siffra och specialtecken")]
        [Display(Name = "Lösenord")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Du måste bekräfta lösenordet")]
        [Compare(nameof(Password), ErrorMessage = "Lösenorden matchar inte varandra")]
        [Display(Name = "Bekräfta lösenord")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

        [Display(Name = "Användarbild")]
        [DataType(DataType.Upload)]
        public IFormFile? ImageFile { get; set; }

        [Required(ErrorMessage = "Du måste acceptera villkoren")]
        [Display(Name = "Accepterar villkor")] 
        public bool TermsAndConditions { get; set; } = false;


        public static implicit operator AppUser(RegisterViewModel viewModel) 
        {
            return new AppUser
            {
                UserName = viewModel.Email,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                PhoneNumber = viewModel.Mobile,
                CompapanyName = viewModel.Company,
            };
        }
        public static implicit operator AddressEntity(RegisterViewModel viewModel)
        {
            return new AddressEntity
            {
                StreetName = viewModel.StreetName,
                PostalCode = viewModel.PostalCode,
                City = viewModel.City,
            };
        }

    }
}
