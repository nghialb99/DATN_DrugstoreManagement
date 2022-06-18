using Microsoft.AspNetCore.Mvc;

namespace DrugstoreManagement.WebApp.Controllers
{
    public class InventoryController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
