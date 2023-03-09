using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class EducationGroupController : Controller
    {
        private readonly IEducationGroupService _educationGroupServices;

        public EducationGroupController(IEducationGroupService educationGroupService)
        {
            this._educationGroupServices = educationGroupService;
        }
        // GET: GenderController
        public async Task<IActionResult> Index()
        {
            var Edg = await _educationGroupServices.GetAllAsync();
            return View(Edg);
        }

        // GET: CountryController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var Edug = await _educationGroupServices.FindAsync(x => x.Id == id);
            if (Edug == null)
            {
                return NoContent();
            }

            return View(Edug);
        }

        // GET: CountryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EducationGroup educationGroup)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    await _educationGroupServices.InsertAsync(educationGroup);
                    TempData["SuccessAlert"] = "Education Group Create Successfull";
                }



                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            TempData["errorAlert"] = "Unable To Save Country";
            return View(educationGroup);
        }

        // GET: CountryController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var Edug = await _educationGroupServices.FindAsync(x => x.Id == id);
            if (Edug == null)
            {
                return NoContent();
            }

            return View(Edug);
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EducationGroup educationGroup)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var edu = await _educationGroupServices.FindAsync(educationGroup.Id);

                    edu.EducationGroupName = educationGroup.EducationGroupName;
                    await _educationGroupServices.UpdateAsync(edu);
                    TempData["SuccessAlert"] = "Update Successfull";
                }


                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            TempData["errorAlert"] = "Unable to Update";
            return View(educationGroup);
        }

        // GET: CountryController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var edug = await _educationGroupServices.FindAsync(id);
            return View(edug);
        }

        // POST: CountryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var education = await _educationGroupServices.FindAsync(id);
                if (education != null)
                {
                    await _educationGroupServices.DeleteAsync(education);
                }
                TempData["successful"] = "Delete successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }
    }
}
