using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class BloodGroupController : Controller
    {
        private readonly IBloodGroupService _bloodGroupService;

        public BloodGroupController(IBloodGroupService bloodGroupService)
        {
            this._bloodGroupService = bloodGroupService;
        }
        // GET: BloodGroupController
        public async Task<IActionResult> Index()
        {
            var bloodGroup = await _bloodGroupService.GetAllAsync();
            return View(bloodGroup);
        }

        // GET: BloodGroupController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var bloodGroup = await _bloodGroupService.FindAsync(id);
            return View(bloodGroup);
        }

        // GET: ReligionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReligionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BloodGroup bloodGroup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _bloodGroupService.InsertAsync(bloodGroup);
                }
                TempData["successful"] = "department save successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReligionController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var bloodGroup = await _bloodGroupService.FindAsync(id);
            return View(bloodGroup);
        }

        // POST: ReligionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BloodGroup bloodGroup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _bloodGroupService.UpdateAsync(bloodGroup);
                }
                TempData["successful"] = "department update successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReligionController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var bloodGroup = await _bloodGroupService.FindAsync(id);
            return View(bloodGroup);
        }

        // POST: ReligionController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var bloodGroup = await _bloodGroupService.FindAsync(id);
                if (bloodGroup != null)
                {
                    await _bloodGroupService.DeleteAsync(bloodGroup);
                }
                TempData["successful"] = "department delete successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
