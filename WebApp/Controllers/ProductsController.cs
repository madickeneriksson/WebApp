using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ProductsController : Controller
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var viewModel = new ProductsViewModel
        {
            Products = await _productService.GetAllAsync()
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
