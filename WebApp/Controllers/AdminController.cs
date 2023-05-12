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
        private readonly ProductsService _productsService;
        private readonly AuthenticationService _auth;

        public AdminController(ProductsService productsService, AuthenticationService auth)
        {
            _productsService = productsService;
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
                var productModel = await _productsService.CreateAsync(productRegistrationViewModel);
                if(productModel != null) 
                {
                    if (productRegistrationViewModel.Image!= null)
                        await _productsService.UploadImageAsync(productModel, productRegistrationViewModel.Image);
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
