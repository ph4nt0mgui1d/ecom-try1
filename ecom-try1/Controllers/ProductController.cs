using Microsoft.AspNetCore.Mvc;

namespace ecom_try1.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
