using Microsoft.AspNetCore.Mvc;

namespace DrugstoreManagement.WebApp.Controllers
{
    public class CatagoryController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
