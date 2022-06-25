using DrugstoreManagement.ApiIntegration.Interface;
using DrugstoreManagement.ViewModels.System.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrugstoreManagement.WebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoleController : BaseController
    {
        private readonly IRoleApiClient _roleApiClient;
        public RoleController(IRoleApiClient roleApiClient)
        {
            _roleApiClient = roleApiClient;
        }

        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _roleApiClient.GetAllRole();
            if (!result.IsSuccessed) return BadRequest(result.Message);
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(result.ResultObj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleVm request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _roleApiClient.CreateRole(request);

            if (result.IsSuccessed)
            {
                TempData["result"] = "Thêm mới Role: " + request.Name + " thành công";
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
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(RoleVm request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _roleApiClient.UpdateRole(request);

            return View(result);
        }

        [HttpGet]
        public IActionResult DeleteRole(Guid id)
        {
            return View(new RoleVm() { Id = id});
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRole(RoleDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            
            var result = await _roleApiClient.DeleteRole(request.Id);

            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa Role thành công";
                return RedirectToAction("Index");
            }
            else TempData["result"] = result.Message;

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }
    }
}
