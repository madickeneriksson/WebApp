using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels;

public class ProductRegistrationViewModel
{
    [Required(ErrorMessage = "Du måste ange ett produktnanmn")]
    [Display(Name = "Produktens namn")]
    public string Name { get; set; } = null!;

    [Display(Name = "Produktbeskrivning (valfritt)")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Du måste ange ett produktpris")]
    [Display(Name = "Produktpris *")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    public static implicit operator ProductEntity(ProductRegistrationViewModel productRegistrationViewModel)
    {
        return new ProductEntity
        {
            Name = productRegistrationViewModel.Name,
            Description = productRegistrationViewModel.Description,
            Price = productRegistrationViewModel.Price
        };
    }
}
