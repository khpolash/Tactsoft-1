using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Service.Services;
using Microsoft.EntityFrameworkCore;
using Tactsoft.Core.Entities;
using System.Globalization;

namespace Tactsoft.Controllers.Admin
{
    public class FamilyMemberController : Controller
    {
        private readonly IFamilyMemberServices _familyMemberServices;
        private readonly IEmployeeService _employeeService;
        private readonly IRelationShipService _relationShipService;
        public FamilyMemberController(IFamilyMemberServices familyMemberServices, IEmployeeService employeeService, IRelationShipService relationShipService)
        {
            this._familyMemberServices= familyMemberServices;
            this._employeeService = employeeService;
            this._relationShipService = relationShipService;
        }

        // GET: FamilyMemberController
        public async Task<IActionResult> Index()
        {
            var Family=await _familyMemberServices.GetAllAsync(x => x.Employee, e => e.RelationShip);
            return View(Family);
        }

        // GET: FamilyMemberController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var Family = await _familyMemberServices.FindAsync(x => x.Id == id, x => x.Employee, e => e.RelationShip);
            if (Family == null)
            {
                return NotFound();
            }
            return View(Family);
        }

        // GET: FamilyMemberController/Create
        public ActionResult Create()
        {
            ViewData["EmployeeId"]= _employeeService.Dropdown();
            ViewData["RelationShipId"]=_relationShipService.Dropdown();
            return View();
        }

        // POST: FamilyMemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FamilyMember familyMember)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _familyMemberServices.InsertAsync(familyMember);
                    TempData["successAlert"] = "Family Member save successfull.";
                    return RedirectToAction(nameof(Index));
                    
                }
                
            }
            catch
            {
                return View();
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["RelationShipId"] = _relationShipService.Dropdown();
            return View(familyMember);
        }

        // GET: FamilyMemberController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var Family = await _familyMemberServices.FindAsync(x => x.Id == id, e => e.Employee, e => e.RelationShip);
            if (Family == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["RelationShipId"] = _relationShipService.Dropdown();
           
            return View(Family);
        }

        // POST: FamilyMemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FamilyMember familyMember)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Family = await _familyMemberServices.FindAsync(familyMember.Id);
                    if (Family == null)
                    {
                        return NotFound();
                    }
                    Family.EmployeeId = familyMember.EmployeeId;
                    Family.FamilyMemberName = familyMember.FamilyMemberName;
                    Family.RelationShipId = familyMember.RelationShipId;
                    Family.ContactNumber = familyMember.ContactNumber;
                    Family.Address = familyMember.Address;
                   

                    await _familyMemberServices.UpdateAsync(Family);
                    TempData["successAlert"] = "update successfull.";
                    return RedirectToAction(nameof(Index));

                }
            }
            catch
            {
                throw;
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["RelationShipId"] = _relationShipService.Dropdown();
           

            TempData["errorAlert"] = "Operation failed.";
            return View(familyMember);
        }

        // GET: FamilyMemberController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var Family = await _familyMemberServices.FindAsync(x => x.Id == id, e => e.Employee, e => e.RelationShip);
            if (Family == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["RelationShipId"] = _relationShipService.Dropdown();
            return View(Family);
        }

        // POST: FamilyMemberController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, FamilyMember familyMember)
        {

            var Family = await _familyMemberServices.FindAsync(id);
            if (Family != null)
            {
                await _familyMemberServices.DeleteAsync(familyMember);
                TempData["successAlert"] = " remove successfull.";
            }

            TempData["errorAlert"] = "Operation failed.";
            return RedirectToAction(nameof(Index));
        }
    }
}
