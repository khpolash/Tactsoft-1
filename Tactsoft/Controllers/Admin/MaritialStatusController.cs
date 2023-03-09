using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class MaritialStatusController : Controller
    {
        private readonly IMaritialStatusService _maritialStatusService;

        public MaritialStatusController(IMaritialStatusService maritialStatusService)
        {
            this._maritialStatusService = maritialStatusService;
        }
        // GET: MaritialStatusController
        public async Task<IActionResult> Index()
        {
            var maritalstatus = await _maritialStatusService.GetAllAsync();
            return View(maritalstatus);
        }

        // GET: MaritialStatusController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var maritalstatus = await _maritialStatusService.FindAsync(id);
            return View(maritalstatus);
        }

        // GET: MaritialStatusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaritialStatusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MaritialStatus maritialStatus)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _maritialStatusService.InsertAsync(maritialStatus);
                }
                TempData["successful"] = "maritialStatus save successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MaritialStatusController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var maritialStatus = await _maritialStatusService.FindAsync(id);
            return View(maritialStatus);
        }

        // POST: MaritialStatusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MaritialStatus maritialStatus)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _maritialStatusService.UpdateAsync(maritialStatus);
                }
                TempData["successful"] = "maritialStatus update successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MaritialStatusController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var maritialStatus = await _maritialStatusService.FindAsync(id);
            return View(maritialStatus);
        }

        // POST: MaritialStatusController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var maritialStatus = await _maritialStatusService.FindAsync(id);
                if (maritialStatus != null)
                {
                    await _maritialStatusService.DeleteAsync(maritialStatus);
                }
                TempData["successful"] = "maritialStatus delete successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
