using Microsoft.AspNetCore.Mvc;

namespace DrugstoreManagement.WebApp.Controllers
{
    public class StatisticalReportController : Controller
    {
        public IActionResult SalesReport()
        {
            return View();
        }
        public IActionResult ImportReport()
        {
            return View();
        }
        public IActionResult ImportInventoryReport()
        {
            return View();
        }
    }
}
