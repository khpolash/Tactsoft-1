using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class EmploymentHistoryController : Controller
    {
        private readonly IEmploymentHistoryService _employmentHistoryService;
        private readonly IEmployeeService _employeeService;
        private readonly IDesignationService _designationService;

        public EmploymentHistoryController(IEmploymentHistoryService employmentHistoryService,IEmployeeService employeeService,IDesignationService designationService)
        {
            this._employmentHistoryService = employmentHistoryService;
            this._employeeService = employeeService;
            this._designationService = designationService;
        }
        // GET: EmploymentHistoryController
        public async Task<IActionResult> Index()
        {
            var emp = await _employmentHistoryService.GetAllAsync(e => e.Employee,e => e.Designation);
            return View(emp);
        }

        // GET: EmploymentHistoryController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            var service = await _employmentHistoryService.FindAsync(x => x.Id == id, x => x.Employee,x => x.Designation);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // GET: EmploymentHistoryController/Create
        public ActionResult Create()
        {

  
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["DesignationId"] = _designationService.Dropdown();
            return View();
        }
        // POST: EmploymentHistoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmploymentHistory employmentHistory)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    await _employmentHistoryService.InsertAsync(employmentHistory);
                    TempData["SuccessAlert"] = " Insert Successfull";
                    return RedirectToAction(nameof(Index));
                }

                catch
                {
                    return View();
                }
                
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["DesignationId"] = _designationService.Dropdown();
            return View(employmentHistory);
        }

        // GET: EmploymentHistoryController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var emp = await _employmentHistoryService.FindAsync(x => x.Id == id, x => x.Employee, x => x.Designation);
            if (emp == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["DesignationId"] = _designationService.Dropdown();
            return View(emp);
        }

        // POST: EmploymentHistoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmploymentHistory employmentHistory)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var emp = await _employmentHistoryService.FindAsync(employmentHistory.Id);
                    emp.EmployeeId = employmentHistory.EmployeeId;
                    emp.DesignationId = employmentHistory.DesignationId;
                    emp.JobFor = employmentHistory.JobFor;
                    emp.JobTo = employmentHistory.JobTo;
                    emp.Salary = employmentHistory.Salary;
                    emp.ReasonForLeaving = employmentHistory.ReasonForLeaving;

                    await _employmentHistoryService.UpdateAsync(emp);
                    TempData["SuccessAlert"] = "Update Successfull";
                    

                }
                
                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["EmployeeId"] = _employeeService.Dropdown();
                ViewData["DesignationId"] = _designationService.Dropdown();

                return View(employmentHistory);
          
        }
        // GET: EmploymentHistoryController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var emp = await _employmentHistoryService.FindAsync(x => x.Id == id, x => x.Employee,x => x.Designation);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }
        // POST: EmploymentHistoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var serv = await _employmentHistoryService.FindAsync(x => x.Id == id, x => x.Employee, x => x.Designation);
                if (serv != null)
                {
                    await _employmentHistoryService.DeleteAsync(serv);
                    TempData["SuccessAlert"] = "Delete Successfull";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }

            return View();
        }
    }
}
