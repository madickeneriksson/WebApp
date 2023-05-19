using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        var viewModel = new GridCollectionViewModel
        {
            Products = await _productService.GetAllAsync(), 
        };

        return View(viewModel);
    }

    [HttpGet("/products/details/{articleNumber}")]
    public async Task <IActionResult> Details(string articlenumber)
    
        {
            var product = await _productService.GetAsync(articlenumber);

            if (product == null)
            {
                return NotFound(); // Hantera om produkten inte hittas
            }

            return View(product);
        }
    

    public IActionResult Search()
    {
        ViewData["Title"] = "Search for products";
        return View();
    }

}
