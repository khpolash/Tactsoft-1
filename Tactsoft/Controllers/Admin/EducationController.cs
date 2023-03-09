using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Tactsoft.Controllers.Admin
{
    public class EducationController : Controller
    {
        private readonly IEducationService _educationService;
        private readonly IEmployeeService _employeeService;
        private readonly IEducationGroupService _educationGroupService;
        private readonly IDegreeService _degreeService;
        public EducationController(IEducationService educationService, IEmployeeService employeeService, IEducationGroupService educationGroupService, IDegreeService degreeService)
        {
            this._educationService = educationService;
            this._employeeService = employeeService;
            this._educationGroupService = educationGroupService;
            this._degreeService = degreeService;
        }

        // GET: EducationController
        public async Task<IActionResult> Index()
        {
            var Edu= await _educationService.GetAllAsync(x => x.Employee, e => e.EducationGroup, e => e.Degree);
            return View(Edu);
        }

        // GET: EducationController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var Edu = await _educationService.FindAsync(x => x.Id == id, x => x.Employee, e => e.EducationGroup, e => e.Degree);
            if (Edu == null)
            {
                return NoContent();
            }

            return View(Edu);
        }

        // GET: EducationController/Create
        public ActionResult Create()
        {
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["EducationGroupId"] = _educationGroupService.Dropdown();
            ViewData["DegreeId"] = _degreeService.Dropdown();
            
            return View();
        }

        // POST: EducationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Education education)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _educationService.InsertAsync(education);
                    TempData["successAlert"] = "Education save successfull.";
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View();
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["EducationGroupId"] = _educationGroupService.Dropdown();
            ViewData["DegreeId"] = _degreeService.Dropdown();

            TempData["errorAlert"] = "Operation failed.";
            return View(education);
        }

        // GET: EducationController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var Edu = await _educationService.FindAsync(x => x.Id == id, x => x.Employee, e => e.EducationGroup, e => e.Degree);
            if (Edu == null)
            {
                return NoContent();
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["EducationGroupId"] = _educationGroupService.Dropdown();
            ViewData["DegreeId"] = _degreeService.Dropdown();

            return View(Edu);

        }

        // POST: EducationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Education education)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var edu = await _educationService.FindAsync(education.Id);
                    if (edu == null)
                    {
                        return NotFound();
                    }
                    edu.InstituteName = education.InstituteName;
                    edu.PassingYear = education.PassingYear;
                    edu.Remarks = education.Remarks;
                    edu.Result = education.Result;
                    edu.EmployeeId = education.EmployeeId;
                    edu.DegreeId = education.DegreeId;
                    edu.EducationGroupId = education.EducationGroupId;
                    
                    await _educationService.UpdateAsync(edu);
                    TempData["successAlert"] = "Education update successfull.";
                    return RedirectToAction(nameof(Index));

                }
            }
            catch
            {
                throw;
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["EducationGroupId"] = _educationGroupService.Dropdown();
            ViewData["DegreeId"] = _degreeService.Dropdown();

            TempData["errorAlert"] = "Operation failed.";
            return View(education);
        }

        // GET: EducationController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var Edu = await _educationService.FindAsync(x => x.Id == id, x => x.Employee, e => e.EducationGroup, e => e.Degree);
            if (Edu == null)
            {
                return NoContent();
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["EducationGroupId"] = _educationGroupService.Dropdown();
            ViewData["DegreeId"] = _degreeService.Dropdown();
            return View(Edu);

        }

        // POST: EducationController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, Education education)
        {
            var Edu = await _educationService.FindAsync(id);
            if (Edu != null)
            {
                await _educationService.DeleteAsync(Edu);
                TempData["successAlert"] = "Education remove successfull.";
            }

            TempData["errorAlert"] = "Operation failed.";
            return RedirectToAction(nameof(Index));
        }
    }
}
