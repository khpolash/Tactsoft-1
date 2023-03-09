using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class AwardController : Controller
    {
        private readonly IAwardServices _awardServices;
        private readonly IAwardTypeServices _awardTypeServices;
        private readonly IEmployeeService _employeeService;

        public AwardController(IAwardServices awardServices, IAwardTypeServices awardTypeServices, IEmployeeService employeeService)
        {
            this._awardServices = awardServices;
            this._awardTypeServices = awardTypeServices;
            this._employeeService = employeeService;
        }
        // GET: AwardController
        public async Task<IActionResult> Index()
        {
            var award = await _awardServices.GetAllAsync(e => e.AwardType, e => e.Employee);
            return View(award);
        }

        // GET: AwardController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            var award = await _awardServices.FindAsync(x => x.Id == id, x => x.AwardType, x => x.Employee);
            if (award == null)
            {
                return NotFound();
            }
            return View(award);
        }

        // GET: AwardController/Create
        public ActionResult Create()
        {
            ViewData["employeeId"] = _employeeService.Dropdown();
            ViewData["AwardTypeId"] = _awardTypeServices.Dropdown();
            return View();
        }

        // POST: AwardController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Award award)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    await _awardServices.InsertAsync(award);
                    TempData["SuccessAlert"] = "award Insert Successfull";
                }

                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["employeeId"] = _employeeService.Dropdown();
            ViewData["AwardTypeId"] = _awardTypeServices.Dropdown();
            return View(award);
        }

        // GET: AwardController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var award = await _awardServices.FindAsync(x => x.Id == id, x => x.AwardType, x => x.Employee);
            if (award == null)
            {
                return NotFound();
            }
            ViewData["employeeId"] = _employeeService.Dropdown();
            ViewData["AwardTypeId"] = _awardTypeServices.Dropdown();
            return View(award);
        }

        // POST: AwardController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Award award)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var awd = await _awardServices.FindAsync(id);
                    awd.AwardTypeId = award.AwardTypeId;
                    awd.EmployeeId = award.EmployeeId;
                    awd.Prize = award.Prize;
                    awd.Gift = award.Gift;
                    awd.Date = award.Date;
                    
                    await _awardServices.UpdateAsync(awd);
                    TempData["SuccessAlert"] = "Update Successfull";

                }

                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["employeeId"] = _employeeService.Dropdown();
            ViewData["AwardTypeId"] = _awardTypeServices.Dropdown();

            return View(award);
        }
        // GET: AwardController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var award = await _awardServices.FindAsync(x => x.Id == id, x => x.AwardType, x => x.Employee);
            if (award == null)
            {
                return NotFound();
            }
            return View(award);
        }

        // POST: AwardController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Award award)
        {
            var awd = await _awardServices.FindAsync(x => x.Id == id, x => x.AwardType, x => x.Employee);
            if (awd != null)
            {
                await _awardServices.DeleteAsync(award);
                TempData["SuccessAlert"] = "Project Delete Successfull";
            }
            ViewData["employeeId"] = _employeeService.Dropdown();
            ViewData["AwardTypeId"] = _awardTypeServices.Dropdown();
            TempData["errorAlert"] = "Unable to Delete";
            return View(award);
        }
        
    }
}
