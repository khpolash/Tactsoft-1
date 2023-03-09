using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class DegreeController : Controller
    {// GET: CountryController
        private readonly IDegreeService _degreeService;
        public DegreeController(IDegreeService degreeService)
        {
            this._degreeService = degreeService;
        }

        public async Task<IActionResult> Index()
        {
            var Deg = await _degreeService.GetAllAsync();
            return View(Deg);
        }

        // GET: CountryController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var deg = await _degreeService.FindAsync(x => x.Id == id);
            if (deg == null)
            {
                return NoContent();
            }

            return View(deg);
        }

        // GET: CountryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Degree degree)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    await _degreeService.InsertAsync(degree);
                    TempData["SuccessAlert"] = "Degree Create Successfull";
                }



                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            TempData["errorAlert"] = "Unable To Save Country";
            return View(degree);
        }

        // GET: CountryController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var deg = await _degreeService.FindAsync(x => x.Id == id);
            if (deg == null)
            {
                return NoContent();
            }
            return View(deg);
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Degree degree)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var deg = await _degreeService.FindAsync(degree.Id);

                    deg.DegreeName = degree.DegreeName;
                    await _degreeService.UpdateAsync(deg);
                    
                    TempData["SuccessAlert"] = "Update Successfull";
                }


                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            
            TempData["errorAlert"] = "Unable to Update";
            return View(degree);
        }

        // GET: CountryController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var deg = await _degreeService.FindAsync(id);
            return View(deg);
        }

        // POST: CountryController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Deg = await _degreeService.FindAsync(id);
            if (Deg != null)
            {
                await _degreeService.DeleteAsync(Deg);
                TempData["SuccessAlert"] = "Delete Successfull";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
