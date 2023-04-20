using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

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

        [Display(Name = "Gatuadress")]
        public string? StreetName { get; set; }

        [Display(Name = "Postadress")]
        public string? PostalCode { get; set; }

        [Display(Name = "Stad")]
        public string? City { get; set; }

        //Konventera om till userEntity
        public static implicit operator UserEntity(RegisterViewModel registerViewModel)
        {
            var userEntity = new UserEntity
            { Email = registerViewModel.Email };
            userEntity.GenerateSecurePassword(registerViewModel.Password);
            return userEntity;
        }

        public static implicit operator ProfileEntity(RegisterViewModel registerViewModel)
        {
            return new ProfileEntity
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                StreetName = registerViewModel.StreetName,
                PostalCode = registerViewModel.PostalCode,
                City = registerViewModel.City
            };
            
        }
    }
}
