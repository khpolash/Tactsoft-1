using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class AdvanceTypeController : Controller
    {
        private readonly IAdvanceTypeService _advanceTypeService;

        public AdvanceTypeController(IAdvanceTypeService advanceTypeService)
        {
            this._advanceTypeService = advanceTypeService;
        }
        // GET: AdvanceTypeController
        public async Task<IActionResult> Index()
        {
            var adv = await _advanceTypeService.GetAllAsync();
            return View(adv);
        }

        // GET: AdvanceTypeController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var adv = await _advanceTypeService.FindAsync(id);
            return View(adv);
        }

        // GET: AdvanceTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdvanceTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdvanceType advanceType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _advanceTypeService.InsertAsync(advanceType);
                }
                TempData["successful"] = "save successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdvanceTypeController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var adv = await _advanceTypeService.FindAsync(id);
            return View(adv);
        }

        // POST: AdvanceTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AdvanceType advanceType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _advanceTypeService.UpdateAsync(advanceType);
                }
                TempData["successful"] = "update successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdvanceTypeController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var adv = await _advanceTypeService.FindAsync(id);
            return View(adv);
        }

        // POST: AdvanceTypeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var adv = await _advanceTypeService.FindAsync(id);
                if (adv != null)
                {
                    await _advanceTypeService.DeleteAsync(adv);
                }
                TempData["successful"] = "delete successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
