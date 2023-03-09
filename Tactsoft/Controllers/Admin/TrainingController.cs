using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class TrainingController : Controller
    {
        private readonly ITrainingServices _trainingServices;
        private readonly IEmployeeService _employeeService;
        
        public TrainingController(ITrainingServices trainingServices, IEmployeeService employeeService)
        {
            this._trainingServices = trainingServices;
            this._employeeService = employeeService;
            
        }

        // GET: EducationController
        public async Task<IActionResult> Index()
        {
            var Tra = await _trainingServices.GetAllAsync(x => x.Employee);
            return View(Tra);
        }

        // GET: EducationController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var Tra = await _trainingServices.FindAsync(x => x.Id == id, x => x.Employee);
            if (Tra == null)
            {
                return NoContent();
            }

            return View(Tra);
        }

        // GET: EducationController/Create
        public ActionResult Create()
        {
            ViewData["EmployeeId"] = _employeeService.Dropdown();
           

            return View();
        }

        // POST: EducationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Training training)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _trainingServices.InsertAsync(training);
                    TempData["successAlert"] = "Training save successfull.";
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View();
            }
            ViewData["EmployeeId"] = _trainingServices.Dropdown();
            ViewData["EducationGroupId"] = _trainingServices.Dropdown();
            ViewData["DegreeId"] = _trainingServices.Dropdown();

            TempData["errorAlert"] = "Operation failed.";
            return View(training);
        }

        // GET: EducationController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var Edu = await _trainingServices.GetAllAsync(x => x.Employee);
            if (Edu == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            
            return View(Edu);

        }

        // POST: EducationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Training training)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var edu = await _trainingServices.FindAsync(training.Id);
                    if (edu == null)
                    {
                        return NotFound();
                    }
                    edu.TrainingName = training.TrainingName;
                    edu.StartDate = training.StartDate;
                    edu.EndDate = training.EndDate;
                    edu.OrganigationName = training.OrganigationName;
                    edu.EmployeeId = training.EmployeeId;
                    

                    await _trainingServices.UpdateAsync(edu);
                    TempData["successAlert"] = "Training update successfull.";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                throw;
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            

            TempData["errorAlert"] = "Operation failed.";
            return View(training);
        }

        // GET: EducationController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var Edu = await _trainingServices.FindAsync(x => x.Id == id, x => x.Employee);
            if (Edu == null)
            {
                return NoContent();
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            
            return View(Edu);

        }

        // POST: EducationController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var training = await _trainingServices.FindAsync(id);
                if (training != null)
                {
                    await _trainingServices.DeleteAsync(training);
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


