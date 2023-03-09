using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class AllowanceController : Controller
    {
        private readonly IAllowanceSettingServices _allowanceSettingServices;
        public AllowanceController(IAllowanceSettingServices allowanceSettingServices)
        {
           this._allowanceSettingServices = allowanceSettingServices;
        }

        // GET: AllowanceController
        public async Task<IActionResult> Index()
        {
            var Allow= await _allowanceSettingServices.GetAllAsync();
            return View(Allow);
        }

        // GET: AllowanceController/Details/5
        public async Task<IActionResult> Details(int? id)

        {
            var Allow = await _allowanceSettingServices.FindAsync(x => x.Id == id);
            return View(Allow);
        }

        // GET: AllowanceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllowanceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AllowanceSetting allowance)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _allowanceSettingServices.InsertAsync(allowance);
                }
                TempData["successful"] = "save successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AllowanceController/Edit/5
        public async  Task<IActionResult> Edit(int id)
        {
            var Allow = await _allowanceSettingServices.FindAsync(x => x.Id == id);
            if(Allow == null)
            {
                return NotFound();
            }
            return View(Allow);
            
        }

        // POST: AllowanceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AllowanceSetting allowance)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                   var allow= await _allowanceSettingServices.FindAsync(x=>x.Id==id);

                    if (allow == null)
                    {
                        return NotFound();
                    }
                    allow.AllowanceType=allowance.AllowanceType;
                    allow.valuePercetize=allowance.valuePercetize;
                    allow.Value = allowance.Value;
                    await _allowanceSettingServices.UpdateAsync(allow);
                    TempData["successful"] = "save successfully";
                }
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        // GET: AllowanceController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var Allow = await _allowanceSettingServices.FindAsync(x => x.Id == id);
            return View(Allow);
        }

        // POST: AllowanceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var allow = await _allowanceSettingServices.FindAsync(id);
                if (allow != null)
                {
                    await _allowanceSettingServices.DeleteAsync(allow);
                }
                TempData["successful"] = " delete successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
