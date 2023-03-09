using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class StateController : Controller
    {
        private readonly IStateService _stateService;
        private readonly ICountryService _countryService;
        public StateController(IStateService stateService, ICountryService countryService)
        {
            this._stateService = stateService;
            this._countryService = countryService;
        }


        // GET: StateController
        public async Task<IActionResult> Index()
        {
            var State = await _stateService.GetAllAsync();
            ViewData["CountryId"] = _countryService.Dropdown();
            return View(State);
        }

        // GET: StateController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var State = await _stateService.FindAsync(x=>x.Id==id,x=>x.Country);
            ViewData["CountryId"] = _countryService.Dropdown();
            return View(State);
        }

        // GET: StateController/Create
        public ActionResult Create()
        {
            ViewData["CountryId"] = _countryService.Dropdown();
            return View();
        }

        // POST: StateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(State state)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _stateService.InsertAsync(state);
                    TempData["SuccessAlert"] = "State Insert Successfull";

                }
                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["CountryId"] = _countryService.Dropdown();
            TempData["errorAlert"] = "Unable to Create";
            return View(state);
        }

        // GET: StateController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var State = await _stateService.FindAsync(id);
            ViewData["CountryId"] = _countryService.Dropdown();
            return View(State);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: StateController/Edit/5
        public async Task<IActionResult> Edit(int id, State state)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var St = await _stateService.FindAsync(state.Id);

                    St.StateName = state.StateName;
                    St.CountryID = state.CountryID;

                    await _stateService.UpdateAsync(St);
                    TempData["SuccessAlert"] = "State Update Successfull";
                }


                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = _countryService.Dropdown();
            return View(state);
        }

        // GET: StateController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var State = await _stateService.FindAsync(x=>x.Id==id,x=>x.Country);
            if (State == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = _countryService.Dropdown();
            return View(State);
        }

        // POST: StateController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, State state)
        {
            var st = await _stateService.FindAsync(id);
            if (st != null)
            {
                await _stateService.DeleteAsync(st);
                TempData["SuccessAlert"] = "Delete Successfull";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
