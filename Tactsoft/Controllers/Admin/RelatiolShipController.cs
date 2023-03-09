using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class RelatiolShipController : Controller
    {
        private readonly IRelationShipService _relationShipService;

        public RelatiolShipController(IRelationShipService relationShipService)
        {
            this._relationShipService = relationShipService;
        }
        // GET: GenderController
        public async Task<IActionResult> Index()
        {
            var Rel = await _relationShipService.GetAllAsync();
            return View(Rel);
        }

        // GET: CountryController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var Rel = await _relationShipService.FindAsync(x => x.Id == id);
            if (Rel == null)
            {
                return NoContent();
            }

            return View(Rel);
        }

        // GET: CountryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RelationShip relationShip)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    await _relationShipService.InsertAsync(relationShip);
                    TempData["SuccessAlert"] = "Relationship  Create Successfull";
                }



                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            TempData["errorAlert"] = "Unable To Save Country";
            return View(relationShip);
        }

        // GET: CountryController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var Rel = await _relationShipService.FindAsync(x => x.Id == id);
            if (Rel == null)
            {
                return NoContent();
            }

            return View(Rel);
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RelationShip relationShip)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var Rel = await _relationShipService.FindAsync(relationShip.Id);
                    await _relationShipService.UpdateAsync(relationShip);

                    Rel.RelationShipName = relationShip.RelationShipName;
                    TempData["SuccessAlert"] = "Update Successfull";
                }


                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            TempData["errorAlert"] = "Unable to Update";
            return View(relationShip);
        }

        // GET: CountryController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var Rel = await _relationShipService.FindAsync(id);
            return View(Rel);
        }

        // POST: CountryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var relation = await _relationShipService.FindAsync(id);
                if (relation != null)
                {
                    await _relationShipService.DeleteAsync(relation);
                }
                TempData["successful"] = " delete successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }
    }
}

