using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class LeaveController : Controller
    {
        private readonly ILeaveTypeServices _leaveTypeServices;

        public LeaveController(ILeaveTypeServices leaveTypeServices)
        {
            this._leaveTypeServices = leaveTypeServices;
        }
        // GET: LeaveController
        public async Task<IActionResult> Index()
        {
            var leave = await _leaveTypeServices.GetAllAsync();
            return View(leave);
        }

        // GET: LeaveController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var leave = await _leaveTypeServices.FindAsync(id);
            return View(leave);
        }

        // GET: LeaveController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveType leaveType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _leaveTypeServices.InsertAsync(leaveType);
                }
                TempData["successful"] = "gender save successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var leave = await _leaveTypeServices.FindAsync(id);
            return View(leave);
        }

        // POST: LeaveController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LeaveType leaveType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _leaveTypeServices.UpdateAsync(leaveType);
                }
                TempData["successful"] = "gender update successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var leave = await _leaveTypeServices.FindAsync(id);
            return View(leave);
        }

        // POST: LeaveController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var leave = await _leaveTypeServices.FindAsync(id);
                if (leave != null)
                {
                    await _leaveTypeServices.DeleteAsync(leave);
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
