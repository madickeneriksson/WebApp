using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Repositories;
using WebApp.Helpers.Services;
using WebApp.ViewModels;
using System.Linq;
using WebApp.Models.Entities;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ProductRepository _productRepository;

    public HomeController(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IActionResult> Index()
    {
        var viewModel = new HomeIndexViewModel
        {
            Showcase = new ShowcaseViewModel(),

            New = new GridCollectionViewModel
            {
                Title = "New",
                Categories = new List<string> { "All", "Bag", "Dress", "Decoration", "Essentials", "Interior", "Laptops", "Mobile", "Beauty" },
                Products = await _productRepository.GetProductsByTagAsync("New")
            },
            Featured = new FeaturedCompositeViewModel
            {
                UpToSell = new UpToSellViewModel(),
                GridCollection = new GridCollectionViewModel
                {
                    Products = await _productRepository.GetProductsByTagAsync("Featured")
                }
            },
            Popular = new GridCollectionViewModel
            {
                Title = "Popular",
                Products = await _productRepository.GetProductsByTagAsync("Popular")
            }
        };

        return View(viewModel);
    }

}