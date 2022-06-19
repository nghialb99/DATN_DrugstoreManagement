using DrugstoreManagement.ApiIntegration.Interface;
using DrugstoreManagement.Utilities;
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


            return View(data.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var token = HttpContext.Session.GetString("Token");
            GuardAgainst.Null<string>(token);

            var result = await _userApiClient.GetUserById(id, token);
            if (result.IsSuccessed) return RedirectToAction("Index");

            return View(result.ResultObj);
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
            if(result.IsSuccessed) return RedirectToAction("Index");

            return View(request);
        }

        [HttpGet]
        public IActionResult UpdateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserUpdateRequest request)
        {
            if (!ModelState.IsValid) return View();
            var token = HttpContext.Session.GetString("Token");
            GuardAgainst.Null<string>(token);
            var result = await _userApiClient.UpdateUser(request);
            if (result.IsSuccessed) return RedirectToAction("Index");

            return View(result);
        }
    }
}
