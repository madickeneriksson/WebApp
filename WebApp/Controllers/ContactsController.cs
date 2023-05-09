using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ContactsController : Controller
{
    private readonly ContactFormService _contactFormService;

    public ContactsController(ContactFormService contactFormService)
    {
        _contactFormService = contactFormService;
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "Contact Us";
        return View();
    }

    [HttpPost]
    public async Task <IActionResult> Index(ContactformViewModel contactsViewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _contactFormService.CreateAsync(contactsViewModel))
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Något gick fel vid skapandet av produkten");
        }
        return View();
    }


}
