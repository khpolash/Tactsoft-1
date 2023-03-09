using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class AllowensDetailsController : Controller
    {
        private readonly ISalarySetupService _salarySetupService;
        private readonly IAllowensService _allowensSerive;
        private readonly IAllowensDetailsService _allowensDetailsService;

        public AllowensDetailsController(ISalarySetupService salarySetupService, IAllowensService allowensSerive, IAllowensDetailsService allowensDetailsService)
        {
            this._salarySetupService = salarySetupService;
            this._allowensSerive = allowensSerive;
            this._allowensDetailsService = allowensDetailsService;
        }


        // GET: AllowensDetailsController
        public async Task<IActionResult> Index()
        {
            var AllowDet = await _allowensDetailsService.GetAllAsync(x => x.SalarySetup, x => x.Allowens);
            return View(AllowDet);
        }

        // GET: AllowensDetailsController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var AllowDet = await _allowensDetailsService.FindAsync(x=>x.Id==id, x => x.SalarySetup, x => x.Allowens);
            return View(AllowDet);
        }

        // GET: AllowensDetailsController/Create
        public  ActionResult Create()
        {
            ViewData["AllowensId"] = _allowensSerive.Dropdown();
            ViewData["SalarySetupId"] = _salarySetupService.Dropdown();
            return View();
        }

        // POST: AllowensDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AllowensDetails allowensDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _allowensDetailsService.InsertAsync(allowensDetails);
                    TempData["Success"] = "Insert Successfull";
                    return RedirectToAction(nameof(Index));

                }
                
            }
            catch
            {
                return View();
            }
            ViewData["AllowensId"] = _allowensSerive.Dropdown();
            ViewData["SalarySetupId"] = _salarySetupService.Dropdown();
            return View(allowensDetails);
        }

        // GET: AllowensDetailsController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var AllowDet = await _allowensDetailsService.FindAsync(x => x.Id == id);
            if(AllowDet == null)
            {
                NotFound();
            }
            ViewData["AllowensId"] = _allowensSerive.Dropdown();
            ViewData["SalarySetupId"] = _salarySetupService.Dropdown();
            return View(AllowDet);
        }

        // POST: AllowensDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AllowensDetails allowensDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var AllowDet=await _allowensDetailsService.FindAsync(x => x.Id == id);
                    AllowDet.SalarySetupId=allowensDetails.SalarySetupId;
                    AllowDet.Amount = allowensDetails.Amount;
                    AllowDet.Allowens= allowensDetails.Allowens;
                    await _allowensDetailsService.UpdateAsync(AllowDet);
                    TempData["Success"] = "Updated SuccessFull";
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch
            {
                return View();
            }
            ViewData["AllowensId"] = _allowensSerive.Dropdown();
            ViewData["SalarySetupId"] = _salarySetupService.Dropdown();
            return View(allowensDetails);
        }

        // GET: AllowensDetailsController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var AllowDet = await _allowensDetailsService.FindAsync(x => x.Id == id, x => x.SalarySetup, x => x.Allowens);
            if (AllowDet == null)
            {
                NotFound();
            }
            ViewData["AllowensId"] = _allowensSerive.Dropdown();
            ViewData["SalarySetupId"] = _salarySetupService.Dropdown();
            return View(AllowDet);
        }

        // POST: AllowensDetailsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AllowensDetails allowensDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var AllowDet = await _allowensDetailsService.FindAsync(id);
                    if (AllowDet != null)
                    {
                        await _allowensDetailsService.DeleteAsync(allowensDetails);
                        TempData["successAlert"] = " remove successfull.";
                        return RedirectToAction(nameof(Index));

                    }
                    
                }
                
            }
            catch
            {
                return View();
            }
          
            return View(allowensDetails);
        }
    }
}
