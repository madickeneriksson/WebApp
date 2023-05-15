using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels;

public class ProductRegistrationViewModel
{
    [Required(ErrorMessage = "Du måste ange ett artikelnummer")]
    [Display(Name = "Productens artikelnummer")]
    public int Id { get; set; } 

    [Required(ErrorMessage = "Du måste ange ett produktnanmn")]
    [Display(Name = "Produktens namn")]
    public string Name { get; set; } = null!;

    [Display(Name = "Produktbeskrivning (valfritt)")]
    public string? Description { get; set; }

    [Display(Name = "Rating (valfritt)")]
    public string? Rating { get; set; }


    [Required(ErrorMessage = "Du måste ange ett produktpris")]
    [Display(Name = "Produktpris *")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [Display(Name = "Produktbild (valfritt)")]
    [DataType(DataType.Upload)]
    public IFormFile? Image { get; set; } 

    public static implicit operator ProductEntity(ProductRegistrationViewModel productRegistrationViewModel)
    {
        var entity = new ProductEntity
        {
            
            Name = productRegistrationViewModel.Name,
            Description = productRegistrationViewModel.Description,
            Rating= productRegistrationViewModel.Rating,

            Price = productRegistrationViewModel.Price,
        };
        if (productRegistrationViewModel.Image != null)
            entity.ImageUrl = $"{productRegistrationViewModel.Id}_{productRegistrationViewModel.Image?.FileName}";
        return entity;
    }
}
