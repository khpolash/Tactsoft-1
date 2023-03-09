using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Service.Services;
using Microsoft.EntityFrameworkCore;
using Tactsoft.Core.Entities;

namespace Tactsoft.Controllers.Admin
{


    public class NomineeController : Controller
    {
        private readonly INomineeService _nomineeService;
        private readonly IEmployeeService _employeeService;
        private readonly IRelationShipService _relationShipService;
        
        public NomineeController(IEmployeeService employeeService, IRelationShipService relationShipService,
            INomineeService nomineeService)
        {
            this._employeeService = employeeService;
            this._relationShipService = relationShipService;
            this._nomineeService = nomineeService;

        }


        // GET: EmployeeController
        public async Task<IActionResult> Index()
        {
            var Nome = await _nomineeService.GetAllAsync(x => x.Employee, e => e.RelationShip);

            return View(Nome);
        }

        // GET: EmployeeController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var Nome = await _nomineeService.FindAsync(x => x.Id == id, x => x.Employee, e => e.RelationShip);
            if (Nome == null)
            {
                return NotFound();
            }
            return View(Nome);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["RelationShipId"] = _relationShipService.Dropdown();
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Nominee nominee, IFormFile pictureFile)
        {

            if (ModelState.IsValid)
            {
                if (pictureFile != null && pictureFile.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Nominee",
                     pictureFile.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        pictureFile.CopyTo(stream);
                    }
                    nominee.Picture = $"{pictureFile.FileName}";
                }

                await _nomineeService.InsertAsync(nominee);
                TempData["successAlert"] = "Nominee save successfull.";
                return RedirectToAction(nameof(Index));
            }

            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["RelationShipId"] = _relationShipService.Dropdown();

            TempData["errorAlert"] = "Operation failed.";
            return View(nominee);
        }

        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var Nome = await _nomineeService.FindAsync(x => x.Id == id, x => x.Employee, e => e.RelationShip);
            if (Nome == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["RelationShipId"] = _relationShipService.Dropdown();
            return View(Nome);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Nominee nominee, IFormFile pictureFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Nome = await _nomineeService.FindAsync(nominee.Id);

                    if (pictureFile != null && pictureFile.Length > 0)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Nominee",
                         pictureFile.FileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            pictureFile.CopyTo(stream);
                        }
                        nominee.Picture = $"{pictureFile.FileName}";
                    }
                    else
                    {
                        nominee.Picture = Nome.Picture;
                    }
                    Nome.Picture = nominee.Picture;
                    Nome.EmployeeId=nominee.EmployeeId;
                    Nome.NomineeName=nominee.NomineeName;
                    Nome.Address= nominee.Address;
                    Nome.ContactNumber=nominee.ContactNumber;
                    Nome.percentage=nominee.percentage;
                    Nome.RelationShipId=nominee.RelationShipId;


                    await _nomineeService.UpdateAsync(Nome);
                    TempData["successAlert"] = "Nominee update successfull.";
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["RelationShipId"] = _relationShipService.Dropdown();
            TempData["errorAlert"] = "Operation failed.";
            return View(nominee);
        }


        // GET: EmployeeController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var Nome = await _nomineeService.FindAsync(x => x.Id == id, x => x.Employee, e => e.RelationShip);
            if (Nome == null)
            {
                return NotFound();
            }
            return View(Nome);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var Nome = await _nomineeService.FindAsync(id);
                if (Nome != null)
                {
                    await _nomineeService.DeleteAsync(Nome);
                }
                TempData["successful"] = "Employee delete successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }
    }
}
