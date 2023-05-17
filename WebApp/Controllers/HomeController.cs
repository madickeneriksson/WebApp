using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {

        var viewModel = new HomeIndexViewModel
        {
            BestCollection = new GridCollectionViewModel
            {
                Title = "Best Collection",
                Categories = new List<string> { "All", "Bag", "Dress", "Decoration", "Essentials", "Interior", "Laptops", "Mobile", "Beauty" },

            },
            UpToSell = new GridCollectionViewModel
            {


            },


            TopSelling = new GridCollectionViewModel
            {
                Title = "Top selling products in this week",

            }


        };

        return View(viewModel);
    }

}