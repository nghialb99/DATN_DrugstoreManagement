using Microsoft.AspNetCore.Mvc;

namespace DrugstoreManagement.WebApp.Controllers
{
    public class EnterpriseInfoController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
