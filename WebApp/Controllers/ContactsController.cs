using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ContactsController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Contact Us";
        return View();
    }

    [HttpPost]
    public IActionResult Index(ContactsViewModel contactsViewModel)
    {
        ViewData["Title"] = "Contact Us";
        return View(contactsViewModel);
    }
}
