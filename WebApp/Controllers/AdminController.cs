using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly ProductService _productService;
        private readonly AuthenticationService _auth;

        public AdminController(ProductService productService, AuthenticationService auth)
        {
            _productService = productService;
            _auth = auth;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductRegister(ProductRegistrationViewModel productRegistrationViewModel)
        {
            if (ModelState.IsValid)  
            {
                var product = await _productService.CreateAsync(productRegistrationViewModel);
                if (product != null)
                {
                    if (productRegistrationViewModel.Image!= null)
                      await _productService.UploadImageAsync(product, productRegistrationViewModel.Image);
                    return RedirectToAction("index", "admin");
                    
                }
                ModelState.AddModelError("", "Något gick fel vid skapandet av produkten");


            }
            return View();
        }

        public IActionResult ShowCustomer()
        {
            return View();
        }

    }
}
