using Microsoft.AspNetCore.Mvc;

namespace SimpleExample01.Controllers
{
    public class DocumentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
