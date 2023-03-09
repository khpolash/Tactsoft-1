using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class ReferenceController : Controller
    {
        private readonly IReferenceService _referenceService;

        public ReferenceController(IReferenceService referenceService)
        {
            this._referenceService = referenceService;
        }
        // GET: ReferenceController
        public async Task<IActionResult> Index()
        {
            var reff = await _referenceService.GetAllAsync();
            return View(reff);
        }

        // GET: ReferenceController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var rf = await _referenceService.FindAsync(id);
            return View(rf);
        }

        // GET: ReferenceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReferenceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reference reference)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _referenceService.InsertAsync(reference);
                }
                TempData["successful"] = "save successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReferenceController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var rf = await _referenceService.FindAsync(id);
            return View(rf);
        }

        // POST: ReferenceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Reference reference)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _referenceService.UpdateAsync(reference);
                }
                TempData["successful"] = "update successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReferenceController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var rf = await _referenceService.FindAsync(id);
            return View(rf);
        }

        // POST: ReferenceController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var rf = await _referenceService.FindAsync(id);
                if (rf != null)
                {
                    await _referenceService.DeleteAsync(rf);
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
