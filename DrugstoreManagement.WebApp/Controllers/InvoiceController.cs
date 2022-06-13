using Microsoft.AspNetCore.Mvc;

namespace DrugstoreManagement.WebApp.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(ILogger<InvoiceController> logger)
        {
            _logger = logger;
        }
        public IActionResult CreateInvoice()
        {
            return View();
        }
        public IActionResult ManageInvoice()
        {
            return View();
        }

    }
}
