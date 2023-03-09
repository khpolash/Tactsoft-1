using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class AttachmentTypeController : Controller
    {
        private readonly IAttachmentTypeService _attachmentTypeService;
        public AttachmentTypeController(IAttachmentTypeService attachmentTypeService)
        {
            this._attachmentTypeService = attachmentTypeService;
        }

        public async Task<IActionResult> Index()
        {
            var Att = await _attachmentTypeService.GetAllAsync();
            return View(Att);
        }

        // GET: CountryController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var Att = await _attachmentTypeService.FindAsync(x => x.Id == id);
            if (Att == null)
            {
                return NoContent();
            }

            return View(Att);
        }

        // GET: CountryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AttachmentType attachmentType)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _attachmentTypeService.InsertAsync(attachmentType);
                    
                    TempData["SuccessAlert"] = "Attachment Create Successfull";
                }



                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            TempData["errorAlert"] = "Unable To Save Attachment";
            return View(attachmentType);
        }

        // GET: CountryController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var Att = await _attachmentTypeService.FindAsync(x => x.Id == id);
            if (Att == null)
            {
                return NoContent();
            }

            return View(Att);
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AttachmentType attachmentType)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var att = await _attachmentTypeService.FindAsync(attachmentType.Id);

                    att.AttachmentTypeName = attachmentType.AttachmentTypeName;
                    await _attachmentTypeService.UpdateAsync(att);

                    TempData["SuccessAlert"] = "Update Successfull";
                }


                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AttachmentTyppeId"] = _attachmentTypeService.Dropdown();
            TempData["errorAlert"] = "Unable to Update";
            return View(attachmentType);
        }

        // GET: CountryController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var att = await _attachmentTypeService.FindAsync(id);
            return View(att);
        }

        // POST: CountryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var att = await _attachmentTypeService.FindAsync(id);
            if (att != null)
            {
                await _attachmentTypeService.DeleteAsync(att);
                TempData["SuccessAlert"] = "Delete Successfull";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
