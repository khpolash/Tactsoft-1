using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class SalarySetupController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ISalarySetupService _salarySetupService;
        public SalarySetupController(IEmployeeService employeeService, ISalarySetupService salarySetupService)
        {
            this._employeeService = employeeService;
            this._salarySetupService = salarySetupService;
        }

        // GET: SalarySetupController
        public async Task<IActionResult> Index()
        {
            var Salary = await _salarySetupService.GetAllAsync(x => x.Employee);
            return View(Salary);
        }

        // GET: SalarySetupController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var Salary = await _salarySetupService.FindAsync(x => x.Id == id, x => x.Employee);
            return View(Salary);
        }

        // GET: SalarySetupController/Create
        public ActionResult Create()
        {
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            return View();
        }

        // POST: SalarySetupController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SalarySetup salarySetup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _salarySetupService.InsertAsync(salarySetup);
                    TempData["Success"] = "Successfully Insery Salary";
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch
            {
                return View();
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            return View(salarySetup);
        }

        // GET: SalarySetupController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var Salary = await _salarySetupService.FindAsync(x => x.Id == id, x => x.Employee);
            if (Salary == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"]=_employeeService.Dropdown();
            return View(Salary);
        }

        // POST: SalarySetupController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SalarySetup salarySetup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Salary = await _salarySetupService.FindAsync(x => x.Id == id, x => x.Employee);
                    Salary.EmployeeId = salarySetup.EmployeeId;
                    Salary.Basic = salarySetup.Basic;
                    TempData["Success"] = "Update Successfull";
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch
            {
                return View();
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            TempData["Error"] = "Unable to save";
            return View(salarySetup);
        }

        // GET: SalarySetupController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var Salary = await _salarySetupService.FindAsync(x => x.Id == id, x => x.Employee);
            if (Salary == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            return View(Salary);
        }

        // POST: SalarySetupController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, SalarySetup salarySetup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Salary = await _salarySetupService.FindAsync(x => x.Id == id, x => x.Employee);
                    await _salarySetupService.DeleteAsync(salarySetup);
                    TempData["Success"] = "Delete Success";
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch
            {
                return View();
            }
            return View(salarySetup);
        }
    }
}
