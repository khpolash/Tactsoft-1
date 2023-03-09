using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Service.Services;
using Microsoft.EntityFrameworkCore;
using Tactsoft.Core.Entities;
namespace Tactsoft.Controllers.Admin
{
    public class AwardTypeController : Controller
    {
        private readonly IAwardTypeServices _awardTypeServices;

        public AwardTypeController(IAwardTypeServices awardTypeServices)
        {
            this._awardTypeServices = awardTypeServices;
        }
        // GET: AwardTypeController
        public async Task<IActionResult> Index()
        {
            var award = await _awardTypeServices.GetAllAsync();
            return View(award);
        }

        // GET: AwardTypeController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var award = await _awardTypeServices.FindAsync(id);
            return View(award);
        }

        // GET: AwardTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AwardTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AwardType awardType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _awardTypeServices.InsertAsync(awardType);
                }
                TempData["successful"] = "awardType save successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AwardTypeController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var award = await _awardTypeServices.FindAsync(id);
            return View(award);
        }

        // POST: AwardTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AwardType awardType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _awardTypeServices.UpdateAsync(awardType);
                }
                TempData["successful"] = "awardType update successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AwardTypeController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var award = await _awardTypeServices.FindAsync(id);
            return View(award);
        }

        // POST: AwardTypeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var award = await _awardTypeServices.FindAsync(id);
                if (award != null)
                {
                    await _awardTypeServices.DeleteAsync(award);
                }
                TempData["successful"] = "award delete successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
