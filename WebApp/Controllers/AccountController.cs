using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class AccountController : Controller
{
    private readonly UserService _userService;

    public AccountController(UserService userService)
    {
        _userService = userService;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task <IActionResult> Register(RegisterViewModel registerViewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _userService.UserExists(x => x.Email == registerViewModel.Email))
            {
                ModelState.AddModelError("", "Det finns redan en användare med denna e-post");
            }
            else 
            {
                if (await _userService.RegisterAsync(registerViewModel))
                    return RedirectToAction("Index", "Home");
                else
                    ModelState.AddModelError("", "Något gick fel när användare skulle skapas");
            } 
        }
        return View(registerViewModel);    
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _userService.LoginAsync(loginViewModel))
            return RedirectToAction("Index", "Account");

            ModelState.AddModelError("", "Felaktig e-postadress eller lösenord");
        }  
        return View(loginViewModel);
    }


    public IActionResult Index()
    {
        return View();
    }
}
