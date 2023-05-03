using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Authorize] 
    //Skydda sidan i utloggat läge
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
