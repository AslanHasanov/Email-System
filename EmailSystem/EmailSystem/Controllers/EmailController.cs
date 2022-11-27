using Microsoft.AspNetCore.Mvc;

namespace EmailSystem.Controllers
{
    public class EmailController : Controller
    {






        public IActionResult SendEmail()
        {
            return View();
        }
    }
}
