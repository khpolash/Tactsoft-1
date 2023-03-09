using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class DesignationController : Controller
    {
        private readonly IDesignationService _designationService;

        public DesignationController(IDesignationService designationService)
        {
            this._designationService = designationService;
        }
        // GET: DesignationController
        public async Task<IActionResult> Index()
        {
            var designation = await _designationService.GetAllAsync();
            return View(designation);
        }

        // GET: DesignationController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var designation = await _designationService.FindAsync(id);
            return View(designation);
        }

        // GET: DesignationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DesignationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Designation designation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _designationService.InsertAsync(designation);
                }
                TempData["successful"] = "designation save successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DesignationController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var designation = await _designationService.FindAsync(id);
            return View(designation);
        }

        // POST: DesignationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Designation designation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _designationService.UpdateAsync(designation);
                }
                TempData["successful"] = "designation update successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DesignationController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var designation = await _designationService.FindAsync(id);
            return View(designation);
        }

        // POST: DesignationController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var designation = await _designationService.FindAsync(id);
                if (designation != null)
                {
                    await _designationService.DeleteAsync(designation);
                }
                TempData["successful"] = "designation delete successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
