using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ProductsController : Controller
{
    private readonly ProductsService _productsService;

    public ProductsController(ProductsService productsService)
    {
        _productsService = productsService;
    }

    public IActionResult Index()
    {

        var viewModel = new ProductsIndexViewModel
        {
            All = new GridCollectionViewModel
            {
                Title = "All Products",
                Categories = new List<string> { "All", "Mobile" }
            }
        };
        return View(viewModel);
    }
    public IActionResult Details()
    {
        ViewData["Title"] = "Search for products";
        return View();
    }

    public IActionResult Search()
    {
        ViewData["Title"] = "Search for products";
        return View();
    }

}
