using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class DeductionController : Controller
    {
        // GET: DeductionController
        private readonly IDeductionService _deductionService;
        public DeductionController(IDeductionService deductionService)
        {
            this._deductionService = deductionService;
        }
        
        public async Task<IActionResult> Index()
        {
            var Ded = await _deductionService.GetAllAsync();
            return View(Ded);
        }

        // GET: DeductionController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var Ded = await _deductionService.FindAsync(id);
            return View(Ded);
        }

        // GET: DeductionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeductionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Deduction deduction)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _deductionService.InsertAsync(deduction);
                    TempData["Success"] = "Save Successfully";
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View();
            }
            TempData["Error"] = "Unable to Create";
            return View(deduction);
        }

        // GET: DeductionController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var Ded = await _deductionService.FindAsync(x => x.Id == id);
            return View(Ded);
        }

        // POST: DeductionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Deduction deduction)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _deductionService.UpdateAsync(deduction);
                    TempData["Success"] = "Update Successfully";
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View();
            }
            TempData["Error"] = "Unable to update";
            return View(deduction);
        }

        // GET: DeductionController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var Ded = await _deductionService.FindAsync(x => x.Id == id);
            return View(Ded);
        }

        // POST: DeductionController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Deduction deduction)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    await _deductionService.DeleteAsync(deduction);
                    TempData["Success"] = "Delete Successfully";
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View();
            }
            TempData["Error"] = "Unable to Delete";
            return View(deduction);
        }
    }
}
