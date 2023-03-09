using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class GenderController : Controller
    {
        private readonly IGenderServices _genderServices;

        public GenderController(IGenderServices genderServices)
        {
            _genderServices = genderServices;
        }
        // GET: GenderController
        public async Task<IActionResult> Index()
        {
            var gender = await _genderServices.GetAllAsync();
            return View(gender);
        }

        // GET: GenderController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var gender = await _genderServices.FindAsync(id);
            return View(gender);
        }

        // GET: GenderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Gender gender)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _genderServices.InsertAsync(gender);
                }
                TempData["successful"] = "gender save successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GenderController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var gender = await _genderServices.FindAsync(id);
            return View(gender);
        }

        // POST: GenderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Gender gender)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _genderServices.UpdateAsync(gender);
                }
                TempData["successful"] = "gender update successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GenderController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var gender = await _genderServices.FindAsync(id);
            return View(gender);
        }

        // POST: GenderController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var gender = await _genderServices.FindAsync(id);
                if (gender != null)
                {
                    await _genderServices.DeleteAsync(gender);
                }
                TempData["successful"] = "gender delete successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
