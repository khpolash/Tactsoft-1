using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class EmployeeTypeController : Controller
    {
        private readonly IEmployeeTypeServices _services;
        public EmployeeTypeController(IEmployeeTypeServices services)
        {
            this._services = services;
        }
        // GET: EmployeeTypeController
        public async Task<IActionResult> Index()
        {
            var EmpTyp = await _services.GetAllAsync();
            return View(EmpTyp);
        }

        // GET: EmployeeTypeController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var EmpType=await _services.FindAsync(x=>x.Id == id);
            return View(EmpType);
        }

        // GET: EmployeeTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeType employeeType)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    await _services.InsertAsync(employeeType);
                    TempData["SuccessAlert"] = "Insert Successfully";
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch
            {
                return View();
            }
            TempData["ErrorAlert"] = "Sorry unable to Insert";
            return View(employeeType);
        }

        // GET: EmployeeTypeController/Edit/5
        public async Task <IActionResult> Edit(int id)
        {
            var EmpType = await _services.FindAsync(x => x.Id == id);
            return View(EmpType);
        }

        // POST: EmployeeTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( EmployeeType employeeType)
        {
            try
            {
                var EmpType = await _services.FindAsync(employeeType.Id);
                if(EmpType == null)
                {
                    NotFound();
                }

                EmpType.DateOfParmanent = employeeType.DateOfParmanent;
                EmpType.Remarks = employeeType.Remarks;
                EmpType.Sat= employeeType.Sat;
                EmpType.Sun= employeeType.Sun;
                EmpType.Mon= employeeType.Mon;
                EmpType.Thu= employeeType.Thu;
                EmpType.Wed= employeeType.Wed;
                EmpType.Tue= employeeType.Tue;
                EmpType.Fri= employeeType.Fri;
                await _services.UpdateAsync(EmpType);
                TempData["SuccessAlert"] = "Update Successfully";
            }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EmployeeTypeController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var EmpType = await _services.FindAsync(x => x.Id == id);
            return View(EmpType);
            
        }

        // POST: EmployeeTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete( EmployeeType employeeType)
        {
            var EmpType = await _services.FindAsync(employeeType.Id);
            if (EmpType == null)
            {
                NotFound();
            }
            await _services.DeleteAsync(EmpType);
            TempData["SuccessAlert"] = "Delete Success";
            return View(EmpType);

        }
    }
}
