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
        private readonly TagService _tagService;
        private readonly ProductCategoryService _categoryService;

        public AdminController(ProductService productService, AuthenticationService auth, TagService tagService, ProductCategoryService categoryService)
        {
            _productService = productService;
            _auth = auth;
            _tagService = tagService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task <IActionResult> ProductRegister()
        {
            ViewBag.Tags = await _tagService.GetAllTagsAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductRegister(ProductRegistrationViewModel productRegistrationViewModel, string[] tags, string[] categorys)
        {
            if (ModelState.IsValid)  
            {
                var product = await _productService.CreateAsync(productRegistrationViewModel);
                if (product != null)
                {
                    await _productService.AddProductTagsAsync(productRegistrationViewModel,tags);



                    if (productRegistrationViewModel.Image!= null)
                      await _productService.UploadImageAsync(product, productRegistrationViewModel.Image);
                    return RedirectToAction("index", "admin");
                    
                }
                ModelState.AddModelError("", "Något gick fel vid skapandet av produkten");


            }
            ViewBag.Tags = await _tagService.GetAllTagsAsync(tags);

            return View();
        }

        [HttpGet]
        public async Task <IActionResult> ShowCustomer()
        {
           var customer = await _auth.GetUsersAsync();
            return View(customer);
        }

        
       


    }
}
