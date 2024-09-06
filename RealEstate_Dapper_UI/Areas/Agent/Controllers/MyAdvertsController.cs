using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Areas.Agent.Controllers
{
    [Area("Agent")]
    public class MyAdvertsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
