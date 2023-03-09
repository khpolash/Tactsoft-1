using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class ReligionController : Controller
    {
        private readonly IReligionService _religionService;

        public ReligionController(IReligionService religionService)
        {
            this._religionService = religionService;
        }

        // GET: ReligionController
        public async Task<IActionResult> Index()
        {
            var religion = await _religionService.GetAllAsync();
            return View(religion);
        }

        // GET: ReligionController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var religion = await _religionService.FindAsync(id);
            return View(religion);
        }

        // GET: ReligionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReligionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Religion religion)
        {
            try
            {
                if(ModelState.IsValid)
                    {
                    await _religionService.InsertAsync(religion);
                    }
                TempData["successful"] = "religion save successfully";
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
            var religion = await _religionService.FindAsync(id);
            return View(religion);
        }

        // POST: ReligionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Religion religion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _religionService.UpdateAsync(religion);
                }
                TempData["successful"] = "religion update successfully";
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
            var religion = await _religionService.FindAsync(id);
            return View(religion);
        }

        // POST: ReligionController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var religion = await _religionService.FindAsync(id);
                if(religion != null)
                {
                    await _religionService.DeleteAsync(religion);
                }
                TempData["successful"] = "religion delete successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
