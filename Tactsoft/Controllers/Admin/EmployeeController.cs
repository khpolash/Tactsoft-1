using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Service.Services;
using Microsoft.EntityFrameworkCore;
using Tactsoft.Core.Entities;

namespace Tactsoft.Controllers.Admin
{
    

    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IReligionService _religionService;
        private readonly IGenderServices _genderServices;
        private readonly IMaritialStatusService _maritialStatusService;
        private readonly ICompanyInfoServices _companyInfoServices;
        private readonly IBranchInfoServices _branchInfoService;
        private readonly IProjectService _projectService;

        public EmployeeController(IEmployeeService employeeService, IReligionService religionService, 
            IGenderServices genderServices, IMaritialStatusService maritialStatusService,
            ICompanyInfoServices companyInfoServices, IBranchInfoServices branchInfoService, 
            IProjectService projectService)
        {
           this._employeeService = employeeService;
           this._religionService = religionService;
           this._genderServices = genderServices;
           this._maritialStatusService = maritialStatusService;
           this._companyInfoServices = companyInfoServices;
           this._branchInfoService = branchInfoService;
           this._projectService = projectService;
            
        }
        
    
        // GET: EmployeeController
        public async Task <IActionResult> Index()
        {
            var Emp=await _employeeService.GetAllAsync(x=>x.Religion,e=>e.Gender,e=>e.MaritialStatus,e=>e.CompanyInfo,e=>e.BranchInfo,e=>e.project);
            
            return View(Emp);
        }

        // GET: EmployeeController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var Emp= await _employeeService.FindAsync(x=>x.Id==id, x => x.Religion, e => e.Gender, e => e.MaritialStatus,
                e => e.CompanyInfo, e => e.BranchInfo, e => e.project);
            if (Emp == null)
            {
                return NotFound();
            }
            return View(Emp);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            ViewData["ReligionId"] = _religionService.Dropdown();
            ViewData["GenderId"] = _genderServices.Dropdown();
            ViewData["MaritialStatusId"] = _maritialStatusService.Dropdown();
            ViewData["CompanyInfoId"] = _companyInfoServices.Dropdown();
            ViewData["BranchInfoId"] = _branchInfoService.Dropdown();
            ViewData["ProjectId"] = _projectService.Dropdown();
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult>  Create(Employee employee, IFormFile pictureFile)
        {

            if (ModelState.IsValid)
            {
                if (pictureFile != null && pictureFile.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/employees",
                     pictureFile.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        pictureFile.CopyTo(stream);
                    }
                    employee.Picture = $"{pictureFile.FileName}";
                }

                await _employeeService.InsertAsync(employee);
                TempData["successAlert"] = "Employee save successfull.";
                return RedirectToAction(nameof(Index));
            }            
            
            ViewData["ReligionId"] = _religionService.Dropdown();
            ViewData["GenderId"] = _genderServices.Dropdown();
            ViewData["MaritialStatus"] = _maritialStatusService.Dropdown();

            TempData["errorAlert"] = "Operation failed.";
            return View(employee);
        }

        // GET: EmployeeController/Edit/5
        public async Task <IActionResult> Edit(int id)
        {
            var Emp = await _employeeService.FindAsync(x => x.Id == id, x => x.Religion, e => e.Gender, e => e.MaritialStatus,
               e => e.CompanyInfo, e => e.BranchInfo, e => e.project);
            if (Emp == null)
            {
                return NotFound();
            }
            ViewData["ReligionId"] = _religionService.Dropdown();
            ViewData["GenderId"] = _genderServices.Dropdown();
            ViewData["MaritialStatusId"] = _maritialStatusService.Dropdown();
            ViewData["CompanyInfoId"] = _companyInfoServices.Dropdown();
            ViewData["BranchInfoId"] = _branchInfoService.Dropdown();
            ViewData["ProjectId"] = _projectService.Dropdown();
            
            return View(Emp);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(Employee employee, IFormFile pictureFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var emp = await _employeeService.FindAsync(employee.Id);

                    if (pictureFile != null && pictureFile.Length > 0)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/employees",
                         pictureFile.FileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            pictureFile.CopyTo(stream);
                        }
                        employee.Picture = $"{pictureFile.FileName}";
                    }
                    else
                    {
                        employee.Picture = emp.Picture;
                    }
                    emp.Picture = employee.Picture;
                    emp.FristName = employee.FristName;
                    emp.MiddleName = employee.MiddleName;
                    emp.LastName = employee.LastName;
                    emp.NID = employee.NID;
                    emp.ReligionId = employee.ReligionId;
                    emp.DateOfBirth = employee.DateOfBirth;
                    emp.MaritialStatusId = employee.MaritialStatusId;
                    emp.BrancehId=employee.BrancehId;
                    emp.Nationalaty=employee.Nationalaty;
                    emp.CompanyId=employee.CompanyId;
                    emp.GenderId=employee.GenderId;
                    emp.ProjectId=employee.ProjectId; 
                    emp.JoiningDate=employee.JoiningDate;
                    emp.UserName = employee.UserName;
                    emp.Password = employee.Password;

                    await _employeeService.UpdateAsync(emp);
                    TempData["successAlert"] = "Employee update successfull.";
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReligionId"] = _religionService.Dropdown();
            ViewData["GenderId"] = _genderServices.Dropdown();
            ViewData["MaritialStatus"] = _maritialStatusService.Dropdown();
            ViewData["CompanyInfoId"] = _companyInfoServices.Dropdown();
            ViewData["BranchInfoId"] = _branchInfoService.Dropdown();
            ViewData["ProjectId"] = _projectService.Dropdown();

            TempData["errorAlert"] = "Operation failed.";
            return View(employee);
        }
    

        // GET: EmployeeController/Delete/5
        public async Task <IActionResult> Delete(int id)
        {
            var employee = await _employeeService.FindAsync(x => x.Id == id, x => x.Religion, e => e.Gender, e => e.MaritialStatus,
               e => e.CompanyInfo, e => e.BranchInfo, e => e.project);
        if (employee == null)
        {
            return NotFound();
        }
            ViewData["ReligionId"] = _religionService.Dropdown();
            ViewData["GenderId"] = _genderServices.Dropdown();
            ViewData["MaritialStatusId"] = _maritialStatusService.Dropdown();
            ViewData["CompanyInfoId"] = _companyInfoServices.Dropdown();
            ViewData["BranchInfoId"] = _branchInfoService.Dropdown();
            ViewData["ProjectId"] = _projectService.Dropdown();

            return View(employee);
    }

        // POST: EmployeeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var employee = await _employeeService.FindAsync(id);
                if (employee != null)
                {
                    await _employeeService.DeleteAsync(employee);
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
