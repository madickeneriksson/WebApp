using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services;
using WebApp.Models.dtos;
using WebApp.Models.Identity;
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
        private readonly UserManager<AppUser> _userManager;


        public AdminController(ProductService productService, AuthenticationService auth, TagService tagService, UserManager<AppUser> userManager)
        {
            _productService = productService;
            _auth = auth;
            _tagService = tagService;
            _userManager = userManager;
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

        [HttpPost]
        public async Task<IActionResult> ChangeRole(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var currentRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
                await _userManager.AddToRoleAsync(user, role);
            }

            return RedirectToAction("ShowCustomer");
        }

        public IActionResult RegisterUser()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _auth.UserAlreadyExistsAsync(x => x.Email == viewModel.Email))
                    ModelState.AddModelError("", "Ett konto med samma email finns redan");

                if (await _auth.RegisterUserAsync(viewModel))
                    return RedirectToAction("index", "admin");
            }
            return View(viewModel);
        }

      

    }
}
