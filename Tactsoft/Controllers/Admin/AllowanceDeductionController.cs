using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class AllowanceDeductionController : Controller
    {
        private readonly IAllowanceSetupService _allowanceSetupservices;
        public AllowanceDeductionController(IAllowanceSetupService allowanceSetupservices)
        {
            this._allowanceSetupservices = allowanceSetupservices;
        }

        // GET: AllowanceDeductionController
        public async Task<IActionResult> Index()
        {
            var Allow= await _allowanceSetupservices.GetAllAsync();   
            return View(Allow);
        }

        // GET: AllowanceDeductionController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var Allow=await _allowanceSetupservices.FindAsync(x=>x.Id==id);
            return View(Allow);
        }

        // GET: AllowanceDeductionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllowanceDeductionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AllowanceSetup allowance)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _allowanceSetupservices.InsertAsync(allowance);
                }
                TempData["successful"] = "save successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AllowanceDeductionController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var Allow = await _allowanceSetupservices.FindAsync(x => x.Id == id);
            if (Allow == null)
            {
                return NotFound();
            }
            return View(Allow);

        }


        // POST: AllowanceDeductionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AllowanceSetup allowance)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var allow = await _allowanceSetupservices.FindAsync(x => x.Id == id);

                    if (allow == null)
                    {
                        return NotFound();
                    }
                    
                   allow.AllowanceType=allowance.AllowanceType;
                    allow.ValuePercetize=allowance.ValuePercetize;
                    allow.Value= allowance.Value;
                    await _allowanceSetupservices.UpdateAsync(allow);
                    TempData["successful"] = "save successfully";
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        // GET: AllowanceDeductionController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var Allow = await _allowanceSetupservices.FindAsync(x => x.Id == id);
            return View(Allow);
        }

        // POST: AllowanceDeductionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AllowanceSetup allowanceSetup)
        {
            try
            {
                var allow = await _allowanceSetupservices.FindAsync(id);
                if (allow != null)
                {
                    await _allowanceSetupservices.DeleteAsync(allow);
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
