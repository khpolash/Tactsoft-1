using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IStateService _stateService;
        public CityController(ICityService cityService, IStateService stateService)
        {
            
            this._cityService = cityService;
            this._stateService = stateService;
        }


        // GET: StateController
        public async Task<IActionResult> Index()
        {
            var City = await _cityService.GetAllAsync();
            ViewData["StateId"] = _stateService.Dropdown();
            return View(City);
        }

        // GET: StateController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var City = await _cityService.FindAsync(id);
            if (City == null)
            {
                return NotFound();
            }
            ViewData["StateId"] = _stateService.Dropdown();
            return View(City);
        }

        // GET: StateController/Create
        public ActionResult Create()
        {
            ViewData["StateId"] = _stateService.Dropdown();
            return View();
        }

        // POST: StateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(City city)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _cityService.InsertAsync(city);
                    TempData["SuccessAlert"] = "State Insert Successfull";

                }
                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["StateId"] = _stateService.Dropdown();
            TempData["errorAlert"] = "Unable to Create";
            return View(city);
        }

        // GET: StateController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var city = await _cityService.FindAsync(id);
            ViewData["StateId"] = _stateService.Dropdown();
            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: StateController/Edit/5
        public async Task<IActionResult> Edit(int id, City city)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var Ct = await _cityService.FindAsync(city.Id);

                   Ct.CityName=city.CityName;
                    Ct.StateId=city.StateId;

                    await _cityService.UpdateAsync(Ct);
                    TempData["SuccessAlert"] = "State Update Successfull";
                }


                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateId"] = _stateService.Dropdown();
            return View(city);
        }

        // GET: StateController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var city = await _cityService.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            ViewData["StateId"] = _stateService.Dropdown();
            return View(city);
        }

        // POST: StateController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, City city)
        {
            var st = await _cityService.FindAsync(id);
            if (st != null)
            {
                await _cityService.DeleteAsync(st);
                TempData["SuccessAlert"] = "Delete Successfull";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

