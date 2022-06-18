using DrugstoreManagement.ApiIntegration.Interface;
using DrugstoreManagement.ViewModels.System.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace DrugstoreManagement.WebApp.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserApiClient _userApiClient;
        public UserController(IUserApiClient userApiClient)
        {
            _userApiClient = userApiClient;
        }
        public async Task<IActionResult> Index(string keyword = " ", bool lockoutEnabled = true,
            int pageIndex = 1, int pageSize = 20)
        {
            var request = new GetUserPagingRequest()
            {
                keyword = keyword,
                lockoutEnabled = lockoutEnabled,
                pageIndex = pageIndex,
                pageSize = pageSize,
                BearerToken = HttpContext.Session.GetString("Token"),
        };
            var data = await _userApiClient.GetUsersPagings(request);
            ViewBag.Keyword = keyword;


            return View(data);
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
            request.BearerToken = HttpContext.Session.GetString("Token");
            var result = await _userApiClient.CreateAcount(request);
            if(result) return RedirectToAction("Index");

            return View(request);
        }
    }
}
