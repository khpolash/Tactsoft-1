using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class CountryController : Controller
    {
        // GET: CountryController
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            this._countryService = countryService;
        }

        public async Task<IActionResult> Index()
        {
            var Coun = await _countryService.GetAllAsync();
            return View(Coun);
        }

        // GET: CountryController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var country = await _countryService.FindAsync(x => x.Id == id);
            if (country == null)
            {
                return NoContent();
            }

            return View(country);
        }

        // GET: CountryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Country country)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    await _countryService.InsertAsync(country);
                    TempData["SuccessAlert"] = "Country Create Successfull";
                }



                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            TempData["errorAlert"] = "Unable To Save Country";
            return View(country);
        }

        // GET: CountryController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var Coun = await _countryService.FindAsync(id);
            if (Coun == null)
            {
                return NotFound();
            }
            return View(Coun);
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Country country)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var Coun = await _countryService.FindAsync(country.Id);

                    Coun.CountryName = country.CountryName;
                    Coun.CountryCode = country.CountryCode;
                    await _countryService.UpdateAsync(Coun);
                    TempData["SuccessAlert"] = "Update Successfull";
                    
                    
                }


                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            TempData["errorAlert"] = "Unable to Update";
            return View(country);
        }

        // GET: CountryController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var Coun = await _countryService.FindAsync(id);
            return View(Coun);
        }

        // POST: CountryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Coun = await _countryService.FindAsync(id);
            if (Coun != null)
            {
                await _countryService.DeleteAsync(Coun);
                TempData["SuccessAlert"] = "Delete Successfull";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
