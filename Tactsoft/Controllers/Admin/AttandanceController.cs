using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class AttandanceController : Controller
    {
        private readonly IAttandanceService _attandanceService;
        private readonly IEmployeeService _employeeService;
        public AttandanceController(IEmployeeService employeeService, IAttandanceService attandanceService)
        {
            this._attandanceService = attandanceService;
            this._employeeService= employeeService;
        }
        // GET: AttandanceController
        public async Task<IActionResult> Index()
        {
            var Atten = await _attandanceService.GetAllAsync(x => x.Employee);
            return View(Atten);
        }

        // GET: AttandanceController/Details/5
        public async Task<IActionResult> Details(int? id)

        {
            var Atten = await _attandanceService.FindAsync(x => x.Id == id,x=>x.Employee);
            if (Atten == null)
            {
                return NotFound();
            }
            return View(Atten);
        }

        // GET: AttandanceController/Create
        public ActionResult Create()
        {
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            return View();
        }

        // POST: AttandanceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Attandance attandance)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _attandanceService.InsertAsync(attandance);
                    TempData["successAlert"] = "Save successfull.";
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch
            {
                return View();
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            return View(attandance);
        }

        // GET: AttandanceController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var att = await _attandanceService.FindAsync(x => x.Id == id, x => x.Employee);
            if (att == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            return View(att);
        }

        // POST: AttandanceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Attandance attandance)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Att = await _attandanceService.FindAsync(attandance.Id);
                    if (Att == null)
                    {
                        return NotFound();
                    }
                    Att.AttandanceDate = attandance.AttandanceDate;
                    Att.EmployeeId = attandance.EmployeeId;
                    Att.Present = attandance.Present;
                    Att.Remarks = attandance.Remarks;

                    await _attandanceService.UpdateAsync(Att);
                    TempData["successAlert"] = "update successfull.";
                    return RedirectToAction(nameof(Index));

                }
            }
            catch
            {
                throw;
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
           
            TempData["errorAlert"] = "Operation failed.";
            return View(attandance);
        }

        // GET: AttandanceController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var Atten = await _attandanceService.FindAsync(x => x.Id == id, x => x.Employee);
            if (Atten == null)
            {
                return NotFound();
            }
            
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            return View(Atten);
        }

        // POST: AttandanceController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Attandance attandance)
        {

            var Att = await _attandanceService.FindAsync(id);
            if (Att != null)
            {
                await _attandanceService.DeleteAsync(Att);
                TempData["successAlert"] = " remove successfull.";
            }

            TempData["errorAlert"] = "Operation failed.";
            return RedirectToAction(nameof(Index));
        }
    }
}
