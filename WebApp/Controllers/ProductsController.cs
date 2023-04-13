using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
        
        var viewModel = new ProductsIndexViewModel
         {
            All = new GridCollectionViewModel
            {
                Title = "All Products",
                Categories = new List<string> {"All", "Mobile" }
            }
         };
        return View(viewModel);
    }

    public IActionResult Search()
    {
        ViewData["Title"] = "Search for products";
        return View();
    }

}
