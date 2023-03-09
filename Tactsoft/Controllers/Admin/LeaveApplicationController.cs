using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class LeaveApplicationController : Controller
    {
        private readonly ILeaveApplictionService _leaveApplictionService;
        private readonly IEmployeeService _employeeService;
        private readonly ILeaveTypeServices _leaveTypeServices;
        private readonly IAttachmentService _attachmentService;

        public LeaveApplicationController(ILeaveApplictionService leaveApplictionService, IEmployeeService employeeService, ILeaveTypeServices leaveTypeServices, IAttachmentService attachmentService)
        {
            this._leaveApplictionService = leaveApplictionService;
            this._employeeService = employeeService;
            this._leaveTypeServices = leaveTypeServices;
            this._attachmentService = attachmentService;
        }
        // GET: LeaveApplicationController
        public async Task<IActionResult> Index()
        {
            var lapp = await _leaveApplictionService.GetAllAsync(e => e.Employee, e => e.LeaveType);
            return View(lapp);
        }

        // GET: LeaveApplicationController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            var lapp = await _leaveApplictionService.FindAsync(x => x.Id == id, x => x.Employee, x => x.LeaveType);
            if (lapp == null)
            {
                return NotFound();
            }
            return View(lapp);
        }

        // GET: LeaveApplicationController/Create
        public ActionResult Create()
        {

            ViewData["LeaveTypeId"] = _leaveTypeServices.Dropdown();
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["AttachmentId"] = _attachmentService.Dropdown();

            return View();
        }

        // POST: LeaveApplicationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveApplication leaveApplication, IFormFile DocumentFile)
        {

            if (ModelState.IsValid)
            {
                if (DocumentFile != null && DocumentFile.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Document/employees/Application",
                     DocumentFile.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        DocumentFile.CopyTo(stream);
                    }
                    leaveApplication.AttachmentFile = $"{DocumentFile.FileName}";
                }


                await _leaveApplictionService.InsertAsync(leaveApplication);

                TempData["successAlert"] = "Application save successfull.";
                return RedirectToAction(nameof(Index));
            }

            ViewData["LeaveTypeId"] = _leaveTypeServices.Dropdown();
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["AttachmentId"] = _attachmentService.Dropdown();
            
            TempData["errorAlert"] = "Operation failed.";
            return View(leaveApplication);
        }

        // GET: LeaveApplicationController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var lapp = await _leaveApplictionService.FindAsync(x => x.Id == id, x => x.Employee, x => x.LeaveType);
            if (lapp == null)
            {
                return NotFound();
            }
            ViewData["LeaveTypeId"] = _leaveTypeServices.Dropdown();
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["AttachmentId"] = _attachmentService.Dropdown();
            return View(lapp);
        }

        // POST: LeaveApplicationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveApplication leaveApplication, IFormFile DocumentFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var lapp = await _leaveApplictionService.FindAsync(id);
                    if (DocumentFile != null && DocumentFile.Length > 0)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/employees",
                         DocumentFile.FileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            DocumentFile.CopyTo(stream);
                        }
                        leaveApplication.AttachmentFile = $"{DocumentFile.FileName}";
                    }
                    lapp.EmployeeId = leaveApplication.EmployeeId;
                    lapp.LeaveTypeId = leaveApplication.LeaveTypeId;
                    lapp.StartDate = leaveApplication.StartDate;
                    lapp.EndDate = leaveApplication.EndDate;
                    lapp.AttachmentFile = leaveApplication.AttachmentFile;
                    lapp.Subject = leaveApplication.Subject;
                    lapp.Description = leaveApplication.Description;

                    await _leaveApplictionService.UpdateAsync(lapp);
                    TempData["SuccessAlert"] = "Update Successfull";

                }

                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeaveTypeId"] = _leaveTypeServices.Dropdown();
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["AttachmentId"] = _attachmentService.Dropdown();

            return View(leaveApplication);
        }



        // GET: LeaveApplicationController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var lapp = await _leaveApplictionService.FindAsync(x => x.Id == id, x => x.Employee, x => x.LeaveType);
            if (lapp == null)
            {
                return NotFound();
            }
            return View(lapp);
        }

        // POST: LeaveApplicationController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, LeaveApplication leaveApplication)
        {
            var lapp = await _leaveApplictionService.FindAsync(x => x.Id == id, x => x.Employee, x => x.LeaveType, x => x.AttachmentFile);
            if (lapp != null)
            {
                await _leaveApplictionService.DeleteAsync(leaveApplication);
                TempData["SuccessAlert"] = "Project Delete Successfull";
            }
            ViewData["LeaveTypeId"] = _leaveTypeServices.Dropdown();
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            ViewData["AttachmentId"] = _attachmentService.Dropdown();
            TempData["errorAlert"] = "Unable to Delete";
            return View(leaveApplication);

        }
    }
}
