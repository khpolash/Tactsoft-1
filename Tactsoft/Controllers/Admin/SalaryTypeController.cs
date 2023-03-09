using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class SalaryTypeController : Controller
    {
        private readonly ISalaryTypeService _salaryTypeService;
        public SalaryTypeController(ISalaryTypeService salaryTypeService)
        {
            this._salaryTypeService = salaryTypeService;
        }
        // GET: SalaryTypeController
        public async Task<IActionResult> Index()
        {
            var Salary = await _salaryTypeService.GetAllAsync();
            return View(Salary);
        }

        // GET: SalaryTypeController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var Salary= await _salaryTypeService.FindAsync(id);
            return View(Salary);
        }

        // GET: SalaryTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalaryTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SalaryType salaryType)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    await _salaryTypeService.InsertAsync(salaryType);
                    TempData["Success"] = "Save Successfully";
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch
            {
                return View();
            }
            TempData["Error"] = "Unable to Create";
            return View(salaryType);
        }

        // GET: SalaryTypeController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var Salary = await _salaryTypeService.FindAsync(x => x.Id == id);
            return View(Salary);
        }

        // POST: SalaryTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SalaryType salaryType)
        {
            try
            {
                var Salary = await _salaryTypeService.FindAsync(x => x.Id == id);

                if (Salary==null)
                {
                    NotFound();
                }
                Salary.SalaryTypeName = salaryType.SalaryTypeName;
                
                await _salaryTypeService.UpdateAsync(salaryType);
                TempData["Success"] = "Update Successfully";
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
            TempData["Error"] = "Unable to update";
            return View(salaryType);
        }

        // GET: SalaryTypeController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var Salary = await _salaryTypeService.FindAsync(x => x.Id == id);
            return View(Salary);
        }

        // POST: SalaryTypeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, SalaryType salaryType)
        {
            try
            {
                var Salary = await _salaryTypeService.FindAsync(x => x.Id == id);
                if (Salary==null)
                {
                    NotFound();
                  
                }
                await _salaryTypeService.DeleteAsync(salaryType);
                TempData["Success"] = "Delete Successfully";
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
            TempData["Error"] = "Unable to Delete";
            return View(salaryType);
        }
    }
}
