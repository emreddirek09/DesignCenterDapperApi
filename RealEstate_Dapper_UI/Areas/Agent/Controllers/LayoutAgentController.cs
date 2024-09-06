using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Areas.Agent.Controllers
{
    [Area("Agent")]
    public class LayoutAgentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
