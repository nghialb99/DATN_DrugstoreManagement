using DrugstoreManagement.ApiIntegration.Interface;
using DrugstoreManagement.Utilities;
using DrugstoreManagement.ViewModels.System.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrugstoreManagement.WebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : BaseController
    {
        private readonly IUserApiClient _userApiClient;
        public UserController(IUserApiClient userApiClient)
        {
            _userApiClient = userApiClient;
        }
        public async Task<IActionResult> Index(string keyword , bool lockoutEnabled = false,
            int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetUserPagingRequest()
            {
                keyword = keyword,
                lockoutEnabled = lockoutEnabled,
                pageIndex = pageIndex,
                pageSize = pageSize,
            };
            var data = await _userApiClient.GetUsersPagings(request);
            if(!data.IsSuccessed) return BadRequest(data.Message);
            ViewBag.Keyword = keyword;
 
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }

        //Forbidden
        [AllowAnonymous]
        public IActionResult Forbidden()
        {
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var token = HttpContext.Session.GetString("Token");
            GuardAgainst.Null<string>(token);

            var result = await _userApiClient.GetUserById(id, token);
            if (!result.IsSuccessed) return RedirectToAction("Index");

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
            var result = await _userApiClient.CreateAcount(request);
            
            if (result.IsSuccessed)
            {
                TempData["result"] = "Thêm mới người dùng thành công";
                return RedirectToAction("Index");
            }
            else TempData["result"] = result.Message;

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
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
            if (result.IsSuccessed)
            {
                TempData["result"] = "Cập nhật người dùng thành công";
                return RedirectToAction("Index");
            }

            return View(result);
        }

        [HttpGet]
        public IActionResult LockUser1(Guid id)
        {
            if (!ModelState.IsValid) return View();
            ViewBag.UID = id;
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> LockUser(Guid id)
        {
            if (!ModelState.IsValid) return View();
            var token = HttpContext.Session.GetString("Token");
            GuardAgainst.Null<string>(token);
            var result = await _userApiClient.LockUser(id);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Khóa người dùng thành công";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UnLockUser(Guid id)
        {
            if (!ModelState.IsValid) return View();
            var token = HttpContext.Session.GetString("Token");
            GuardAgainst.Null<string>(token);
            var result = await _userApiClient.UnLockUser(id);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Mở khóa người dùng thành công";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
