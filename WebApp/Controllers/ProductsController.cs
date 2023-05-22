using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services;
using WebApp.Models.dto;
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
    public async Task<IActionResult> Details(string articlenumber)
    {
        var product = await _productService.GetAsync(articlenumber);

        if (product == null)
        {
            return NotFound(); // Hantera om produkten inte hittas
        }

        var viewModel = new ProductDetailsViewModel
        {

            RandomProducts = await _productService.GetRandomProductsAsync(4) // Hämta slumpmässiga produkter.
        };

        var productModel = new Product
        {
            ArticleNumber = product.ArticleNumber,
            Description = product.Description,
            Name = product.Name,
            Price = product.Price,
            ImageUrl= product.ImageUrl
        };

        var detailsViewModel = new ProductDetailsViewModel
        {
            Product = productModel,
            RandomProducts = await _productService.GetRandomProductsAsync(4), // Hämta slumpmässiga produkter.
            ExistingTags = product.Tags
        };

        return View(detailsViewModel);
    }

    private IEnumerable<Product> GetRandomProducts(IEnumerable<Product> products, int count)
    {
        var random = new Random();
        var randomProducts = products.OrderBy(p => random.Next()).Take(count);
        return randomProducts;
    }

    public IActionResult Search()
    {
        return View();
    }

    public IActionResult Cart()
    {
        return View();
    }
}
