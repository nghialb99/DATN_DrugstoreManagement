using DrugstoreManagement.ApiIntegration.Interface;
using DrugstoreManagement.ViewModels.System.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace DrugstoreManagement.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApiClient _userApiClient;
        public UserController(IUserApiClient userApiClient)
        {
            _userApiClient = userApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisterRequest request)
        {
            if (!ModelState.IsValid) return View();
            var result = await _userApiClient.CreateAcount(request);
            if(result) return RedirectToAction("Index");

            return View(result);
        }
    }
}
