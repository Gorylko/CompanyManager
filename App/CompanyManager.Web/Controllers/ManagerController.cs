namespace CompanyManager.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}