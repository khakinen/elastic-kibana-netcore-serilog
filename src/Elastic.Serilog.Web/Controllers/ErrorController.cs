using Microsoft.AspNetCore.Mvc;

namespace Elastic.Serilog.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/error")]
        public IActionResult Index()
        {
            ViewData["Title"] = "An Error Occurred";
            return View("Index");
        }
    }
}