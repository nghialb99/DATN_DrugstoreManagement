using Microsoft.AspNetCore.Mvc;

namespace DrugstoreManagement.WebApp.Controllers
{
    public class ManageUserController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
