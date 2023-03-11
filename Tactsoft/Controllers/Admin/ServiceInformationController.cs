using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class ServiceInformationController : Controller
    {
        private readonly IServiceInformationServices _service;
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        private readonly IDesignationService _designationService;
        public ServiceInformationController(IDesignationService designationService,IDepartmentService departmentService,IEmployeeService employeeService,IServiceInformationServices service)
        {
            this._service=service;
            this._employeeService=employeeService;
            this._departmentService=departmentService;
            this._designationService=designationService;
        }
        // GET: ServiceInformationController
        public async Task<IActionResult> Index()
        {
            var SerInfo = await _service.GetAllAsync(x => x.Employee, x => x.Department, x => x.Designation);
            return View(SerInfo);
        }

        // GET: ServiceInformationController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var SerInfo= await _service.FindAsync(x => x.Id == id,x => x.Employee, x => x.Department, x => x.Designation);
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["DesignationId"]=_designationService.Dropdown();
            ViewData["DepartmentId"]=_departmentService.Dropdown();
            return View(SerInfo);
        }

        // GET: ServiceInformationController/Create
        public ActionResult Create()
        {
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["DesignationId"] = _designationService.Dropdown();
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            return View();
        }

        // POST: ServiceInformationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceInformation serviceInformation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.InsertAsync(serviceInformation);
                    TempData["Success Alert"] = "Insert Successfull";
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch
            {
                return View();
            }
            return View(serviceInformation);
        }

        // GET: ServiceInformationController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var SerInfo = await _service.FindAsync(x => x.Id == id, x => x.Employee, x => x.Department, x => x.Designation);
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["DesignationId"] = _designationService.Dropdown();
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            return View(SerInfo);
           
        }

        // POST: ServiceInformationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServiceInformation serviceInformation)
        {
            if (ModelState.IsValid) {
                try
                {
                    var SerInfo = await _service.FindAsync(serviceInformation.Id);
                    if (SerInfo == null)
                    {
                        NotFound();
                    }
                    SerInfo.EmployeeId = serviceInformation.EmployeeId;
                    SerInfo.DateOfJoining = serviceInformation.DateOfJoining;
                    SerInfo.DepertmentId = serviceInformation.DepertmentId;
                    SerInfo.DesignationId = serviceInformation.DesignationId;
                    await _service.UpdateAsync(SerInfo);
                    TempData["Success Alert"] = "Update Successfully";
                    
                }
             
            catch
            {
                return View();
            }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["DesignationId"] = _designationService.Dropdown();
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            return View(serviceInformation);
        }

        // GET: ServiceInformationController/Delete/5
        public async Task <IActionResult> Delete(int id)
        {
            var SerInfo = await _service.FindAsync(x => x.Id == id, x => x.Employee, x => x.Department, x => x.Designation);
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["DesignationId"] = _designationService.Dropdown();
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            return View(SerInfo);
        }

        // POST: ServiceInformationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ServiceInformation serviceInformation)
        {
            var SerInfo = await _service.FindAsync(serviceInformation.Id);
            if( SerInfo == null )
            {
                NotFound();
            }
            await _service.DeleteAsync(serviceInformation);
            TempData["Success Alert"] = "Delete Successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
