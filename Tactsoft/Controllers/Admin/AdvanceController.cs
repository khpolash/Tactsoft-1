using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class AdvanceController : Controller
    {
        private readonly IAdvanceService _advanceService;
        private readonly IAdvanceTypeService _advanceTypeService;
        private readonly IEmployeeService _employeeService;

        public AdvanceController(IAdvanceService advanceService,IAdvanceTypeService advanceTypeService,IEmployeeService employeeService)
        {
            this._advanceService = advanceService;
            this._advanceTypeService = advanceTypeService;
            this._employeeService = employeeService;
        }
        // GET: AdvanceController
        public async Task<IActionResult> Index()
        {
            var adv = await _advanceService.GetAllAsync(e => e.Employee, e => e.AdvanceType);
            return View(adv);
        }

        // GET: AdvanceController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            var adv = await _advanceService.FindAsync(x => x.Id == id, x => x.Employee, x => x.AdvanceType);
            if (adv == null)
            {
                return NotFound();
            }
            return View(adv);
        }

        // GET: AdvanceController/Create
        public ActionResult Create()
        {

            
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["AdvancetypeId"] = _advanceTypeService.Dropdown();
            
            return View();
        }

        // POST: AdvanceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Advance advance)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    await _advanceService.InsertAsync(advance);
                    TempData["SuccessAlert"] = " Insert Successfull";
                }

                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["AdvancetypeId"] = _advanceTypeService.Dropdown();
            return View(advance);
        }
        // GET: AdvanceController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var service = await _advanceService.FindAsync(x => x.Id == id, x => x.Employee, x => x.AdvanceType);
            if (service == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["AdvancetypeId"] = _advanceTypeService.Dropdown();
            return View(service);
        }

        //POST: AdvanceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Advance advance)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var serv = await _advanceService.FindAsync(advance.Id);

                    serv.EmployeeId = advance.EmployeeId;
                    serv.AdvanceTypeId = advance.AdvanceTypeId;
                    serv.AdvanceDate = advance.AdvanceDate;
                    serv.ApproveAmount = advance.ApproveAmount;
                    serv.MonthlyDeduction = advance.MonthlyDeduction;
                    serv.DisburseYear = advance.DisburseYear;
                    serv.DisburseMonth = advance.DisburseMonth;
                    serv.ApproveBy = advance.ApproveBy;

                    await _advanceService.UpdateAsync(serv);
                    TempData["SuccessAlert"] = "Update Successfull";

                }

                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["AdvancetypeId"] = _advanceTypeService.Dropdown();

            return View(advance);
        }

        // GET: AdvanceController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var att = await _advanceService.FindAsync(x => x.Id == id, x => x.Employee, e => e.AdvanceType);
            if (att == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["AdvancetypeId"] = _advanceTypeService.Dropdown();

            return View(att);
        }

        // POST: AdvanceController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Advance advance)
        {
            var Allow = await _advanceService.FindAsync(id);
            if (Allow != null)
            {
                await _advanceService.DeleteAsync(advance);
                TempData["successAlert"] = " remove successfull.";
            }

            TempData["errorAlert"] = "Operation failed.";
            return RedirectToAction(nameof(Index));
        
    }
    }
}
