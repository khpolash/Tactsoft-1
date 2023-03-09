using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class AttachmentController : Controller
    {   
        private readonly IAttachmentService _attachmentService;
        private readonly IEmployeeService _employeeService;
        private readonly IAttachmentTypeService _attachmentTypeService;

        public AttachmentController(IAttachmentTypeService attachmentTypeService, IEmployeeService employeeService, IAttachmentService attachmentService)
        {
            this._attachmentService= attachmentService;
            this._attachmentTypeService= attachmentTypeService;
            this._employeeService= employeeService;
        }


        // GET: EmployeeController
        public async Task<IActionResult> Index()
        {
            var att = await _attachmentService.GetAllAsync(x => x.Employee, e => e.AttachmentType);

            return View(att);
        }

        // GET: EmployeeController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var att = await _attachmentService.FindAsync(x => x.Id == id, x => x.Employee, e => e.AttachmentType);
            if (att == null)
            {
                return NotFound();
            }
            return View(att);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            ViewData["AttachmentTyppeId"] = _attachmentTypeService.Dropdown();
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Attachment attachment, IFormFile DocumentFile)
        {

            if (ModelState.IsValid)
            {
                if (DocumentFile != null && DocumentFile.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Document/employees",
                     DocumentFile.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        DocumentFile.CopyTo(stream);
                    }
                    attachment.AttachmentFile = $"{DocumentFile.FileName}";
                }
                

                await _attachmentService.InsertAsync(attachment);
                TempData["successAlert"] = "Employee save successfull.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["AttachmentTyppeId"] = _attachmentService.Dropdown();
            ViewData["EmployeeId"] = _employeeService.Dropdown();

            TempData["errorAlert"] = "Operation failed.";
            return View(attachment);
        }


        //public async Task<IActionResult> Create(Attachment attachment, IFormFile DocumentFile)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        if (DocumentFile != null && DocumentFile.Length > 0)
        //        {
        //            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Document/employees",
        //             DocumentFile.FileName);

        //            using (var stream = new FileStream(path, FileMode.Create))
        //            {
        //                DocumentFile.CopyTo(stream);
        //            }
        //            attachment.AttachmentFile = $"{DocumentFile.FileName}";
        //        }

        //        await _attachmentService.InsertAsync(attachment);
        //        TempData["successAlert"] = "Employee save successfull.";
        //        return RedirectToAction(nameof(Index));
        //    } 

        //    ViewData["AttachmentTypeId"] = _attachmentTypeService.Dropdown();
        //    ViewData["EmployeeId"] = _employeeService.Dropdown();

        //    TempData["errorAlert"] = "Operation failed.";
        //    return View(attachment);
        //}

        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var att = await _attachmentService.FindAsync(x => x.Id == id, x => x.Employee, e => e.AttachmentType);
            if (att == null)
            {
                return NotFound();
            }
            ViewData["AttachmentTypeId"] = _attachmentTypeService.Dropdown();
            ViewData["EmployeeId"] = _employeeService.Dropdown();

            return View(att);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Attachment attachment, IFormFile DocumentFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var att = await _attachmentService.FindAsync(attachment.Id);

                    if (DocumentFile != null && DocumentFile.Length > 0)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/employees",
                         DocumentFile.FileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            DocumentFile.CopyTo(stream);
                        }
                        attachment.AttachmentFile = $"{DocumentFile.FileName}";
                    }
                    
                    
                    await _attachmentService.UpdateAsync(att);
                    TempData["successAlert"] = "Attachment update successfull.";
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AttachmentTyppeId"] = _attachmentService.Dropdown();
            ViewData["EmployeeId"] = _employeeService.Dropdown();

            TempData["errorAlert"] = "Operation failed.";
            return View(attachment);
        }


        // GET: EmployeeController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var att = await _attachmentService.FindAsync(x => x.Id == id, x => x.Employee, e => e.AttachmentType);
            if (att == null)
            {
                return NotFound();
            }
            ViewData["AttachmentTypeId"] = _attachmentTypeService.Dropdown();
            ViewData["EmployeeId"] = _employeeService.Dropdown();

            return View(att);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var att = await _attachmentService.FindAsync(id);
            if (att != null)
            {
                await _attachmentService.DeleteAsync(att);
                TempData["successAlert"] = "Attachment remove successfull.";
            }

            TempData["errorAlert"] = "Operation failed.";
            return RedirectToAction(nameof(Index));
        }
    }
}
