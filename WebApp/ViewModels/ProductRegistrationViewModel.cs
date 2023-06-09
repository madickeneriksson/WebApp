﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels;

public class ProductRegistrationViewModel
{
    [Required(ErrorMessage = "Du måste ange ett artikelnummer")]
    [Display(Name = "Productens artikelnummer")]
    public string ArticleNumber { get; set; } = null!;

    [Required(ErrorMessage = "Du måste ange ett produktnanmn")]
    [Display(Name = "Produktens namn")]
    public string Name { get; set; } = null!;

    [Display(Name = "Produktbeskrivning (valfritt)")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Du måste ange ett produktpris")]
    [Display(Name = "Produktpris ")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [Display(Name = "Produktbild (valfritt)")]
    [DataType(DataType.Upload)]
    public IFormFile? Image { get; set; }


    public static implicit operator ProductEntity(ProductRegistrationViewModel productRegistrationViewModel)
    {
        var entity = new ProductEntity
        {
            ArticleNumber= productRegistrationViewModel.ArticleNumber,
            Name = productRegistrationViewModel.Name,
            Description = productRegistrationViewModel.Description,
            Price = productRegistrationViewModel.Price,
        };
        if (productRegistrationViewModel.Image != null)
            entity.ImageUrl = $"{Guid.NewGuid()}_{productRegistrationViewModel.Image?.FileName}";
        return entity;
    }
}
