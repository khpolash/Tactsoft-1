using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class CompanyController : Controller
    {
        private readonly ICompanyInfoServices _companyInfoServices;
        private readonly ICountryService _countryService;
        private readonly IStateService _stateService;
        private readonly ICityService _cityService;
        private readonly IZipCodeService _zipCodeService;
        public CompanyController(ICompanyInfoServices companyInfoServices, ICountryService countryService, IStateService stateService, ICityService cityService, IZipCodeService zipCodeService)
        {
            this._companyInfoServices = companyInfoServices;
            this._countryService = countryService;
            this._stateService = stateService;
            this._cityService = cityService;
            this._zipCodeService = zipCodeService;
        }

        // GET: CompanyController
        public async Task <IActionResult> Index()
        {
            var Company= await _companyInfoServices.GetAllAsync(e=>e.Country,e=>e.State,e=>e.City,e=>e.ZipCode);
            return View(Company);
        }

        // GET: CompanyController/Details/5
        public async Task <IActionResult> Details(int? id)
        {
            var Company = await _companyInfoServices.FindAsync(x=>x.Id==id,e => e.Country, e => e.State, e => e.City, e => e.ZipCode);
            return View(Company);
        }

        // GET: CompanyController/Create
        public ActionResult Create()
        {
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"]=_stateService.Dropdown();
            ViewData["CityId"]=_cityService.Dropdown();
            ViewData["ZipCodeId"]=_zipCodeService.Dropdown();
            return View();
        }

        // POST: CompanyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(CompanyInfo companyInfo)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    await _companyInfoServices.InsertAsync(companyInfo);
                    TempData["successAlert"] = "Employee save successfull.";
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch
            {
                return View();
            }
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();
            ViewData["ZipCodeId"] = _zipCodeService.Dropdown();

            TempData["errorAlert"] = "Operation failed.";
            return View(companyInfo);
        }

        // GET: CompanyController/Edit/5
        public async Task <IActionResult> Edit(int id)
        {
            var Company = await _companyInfoServices.FindAsync(x => x.Id == id, e => e.Country, e => e.State, e => e.City, e => e.ZipCode);
            if(Company== null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();
            ViewData["ZipCodeId"] = _zipCodeService.Dropdown();
            return View(Company);

        }

        // POST: CompanyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CompanyInfo companyInfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var emp = await _companyInfoServices.FindAsync(companyInfo.Id);
                    if (emp == null)
                    {
                        return NotFound();
                    }
                    emp.CompanyName = companyInfo.CompanyName;
                    emp.CompanyAddress = companyInfo.CompanyAddress;
                    emp.Email = companyInfo.Email;
                    emp.CountryId = companyInfo.CountryId;
                    emp.StateId = companyInfo.StateId;
                    emp.CityId = companyInfo.CityId;
                    emp.ZipCodeId = companyInfo.ZipCodeId;
                    emp.ContactNumber = companyInfo.ContactNumber;

                    await _companyInfoServices.UpdateAsync(emp);
                    TempData["successAlert"] = "CompanyInfo update successfull.";
                    return RedirectToAction(nameof(Index));

                }
            }
            catch
            {
                throw;
            }
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();
            ViewData["ZipCodeId"] = _zipCodeService.Dropdown();

            TempData["errorAlert"] = "Operation failed.";
            return View(companyInfo);
        }

        // GET: CompanyController/Delete/5
        public async Task <IActionResult> Delete(int id)
        {
            var Company = await _companyInfoServices.FindAsync(x => x.Id == id, e => e.Country, e => e.State, e => e.City, e => e.ZipCode);
            if (Company == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();
            ViewData["ZipCodeId"] = _zipCodeService.Dropdown();
            return View(Company);
        }

        // POST: CompanyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> DeleteConfirmed(int id)
        {
            var company = await _companyInfoServices .FindAsync(id);
            if (company != null)
            {
                await _companyInfoServices.DeleteAsync(company);
                TempData["successAlert"] = "Company remove successfull.";
            }

            TempData["errorAlert"] = "Operation failed.";
            return RedirectToAction(nameof(Index));
        }
    }
}
