using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;

using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class ServiceInfoController : Controller
    {
        private readonly IServiceInfoService _serviceInfoService;
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        private readonly IDesignationService _designationService;
        private readonly IBranchInfoServices _branchInfoServices;

        public ServiceInfoController(IServiceInfoService serviceInfoService, IEmployeeService employeeService, IDepartmentService departmentService, IDesignationService designationService, IBranchInfoServices branchInfoServices)
        {
            this._serviceInfoService = serviceInfoService;
            this._employeeService = employeeService;
            this._departmentService = departmentService;
            this._designationService = designationService;
            this._branchInfoServices = branchInfoServices;
        }
        // GET: ServiceInfoController
        public async Task<IActionResult> Index()
        {
            var serviceinfo = await _serviceInfoService.GetAllAsync(e => e.Employee, e => e.BranchInfo,e=>e.Department,e=>e.Designation);
            return View(serviceinfo);
        }

        // GET: ServiceInfoController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            var service = await _serviceInfoService.FindAsync(x => x.Id == id, x => x.Employee, x => x.BranchInfo,x=>x.Department,x=>x.Designation);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // GET: ServiceInfoController/Create
        public ActionResult Create()
        {
            
            ViewData["BranchInfoId"] = _branchInfoServices.Dropdown();
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            ViewData["DesignationId"] = _designationService.Dropdown();
            return View();
        }

        // POST: ServiceInfoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceInfo serviceInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    await _serviceInfoService.InsertAsync(serviceInfo);
                    TempData["SuccessAlert"] = "Project Insert Successfull";
                }

                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchInfoId"] = _branchInfoServices.Dropdown();
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            ViewData["DesignationId"] = _designationService.Dropdown();
            return View(serviceInfo);
        }

        // GET: ServiceInfoController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var service = await _serviceInfoService.FindAsync(x => x.Id == id, x => x.Employee, x => x.BranchInfo, x => x.Department, x => x.Designation);
            if (service == null)
            {
                return NotFound();
            }
            ViewData["BranchInfoId"] = _branchInfoServices.Dropdown();
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            ViewData["DesignationId"] = _designationService.Dropdown();
            return View(service);
        }

        // POST: ServiceInfoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceInfo serviceInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var serv = await _serviceInfoService.FindAsync(id);
                    serv.EmployeeId = serviceInfo.EmployeeId;
                    serv.JoiningDate = serviceInfo.JoiningDate;
                    serv.DesignationId = serviceInfo.DesignationId;
                    serv.DepartmentId = serviceInfo.DepartmentId;
                    serv.BranchId = serviceInfo.BranchId;
                    serv.Remarks = serviceInfo.Remarks;
                    await _serviceInfoService.UpdateAsync(serv);
                    TempData["SuccessAlert"] = "Update Successfull";

                }

                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchInfoId"] = _branchInfoServices.Dropdown();
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            ViewData["DesignationId"] = _designationService.Dropdown();

            return View(serviceInfo);
        }

        // GET: ServiceInfoController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var service = await _serviceInfoService.FindAsync(x => x.Id == id, x => x.Employee, x => x.BranchInfo, x => x.Department, x => x.Designation);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // POST: ServiceInfoController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ServiceInfo serviceInfo)
        {
            var serv = await _serviceInfoService.FindAsync(x => x.Id == id, x => x.Employee, x => x.BranchInfo, x => x.Department, x => x.Designation);
            if (serv != null)
            {
                await _serviceInfoService.DeleteAsync(serviceInfo);
                TempData["SuccessAlert"] = "Project Delete Successfull";
            }
            ViewData["BranchInfoId"] = _branchInfoServices.Dropdown();
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            ViewData["DesignationId"] = _designationService.Dropdown();
            TempData["errorAlert"] = "Unable to Delete";
            return View(serviceInfo);
        
        }
    }
}
