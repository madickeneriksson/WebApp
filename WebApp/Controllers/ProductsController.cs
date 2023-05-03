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

    public IActionResult Search()
    {
        ViewData["Title"] = "Search for products";
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(ProductRegistrationViewModel productRegistrationViewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _productsService.CreateAsync(productRegistrationViewModel))
                return RedirectToAction("Index", "Products");

            ModelState.AddModelError("", "Något gick fel vid skapandet av produkten");
        }
        return View();
    }

}
