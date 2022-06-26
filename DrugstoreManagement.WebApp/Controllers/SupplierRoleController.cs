using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrugstoreManagement.WebApp.Controllers
{
    public class SupplierRoleController : BaseController
    {
        // GET: SupplierRoleController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SupplierRoleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SupplierRoleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplierRoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplierRoleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SupplierRoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplierRoleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SupplierRoleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
