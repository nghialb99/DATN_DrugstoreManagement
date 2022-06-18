using Microsoft.AspNetCore.Mvc;

namespace DrugstoreManagement.WebApp.Controllers
{
    public class ManageUserRoleController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
