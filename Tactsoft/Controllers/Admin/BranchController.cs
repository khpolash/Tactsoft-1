using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class BranchController : Controller
    {


        private readonly IBranchInfoServices _branchInfoServices;
        private readonly ICompanyInfoServices _companyInfoServices;
        private readonly ICountryService _countryService;
        private readonly IStateService _stateService;
        private readonly ICityService _cityService;
        private readonly IZipCodeService _zipCodeService;

        public BranchController(IBranchInfoServices branchInfoServices, ICompanyInfoServices companyInfoServices,
            ICountryService countryService, IStateService stateService, ICityService cityService,IZipCodeService zipCodeService)
        {
            this._branchInfoServices = branchInfoServices;
            this._companyInfoServices = companyInfoServices;
            this._countryService = countryService;
            this._stateService = stateService;
            this._cityService = cityService;
            this._zipCodeService = zipCodeService;
        }



        // GET: BranchController
        public async Task<IActionResult> Index()
        {
            var Branch = await _branchInfoServices.GetAllAsync(x => x.CompanyInfo, x => x.Country, x => x.State, x => x.City,x=>x.ZipCode);
            return View(Branch);
        }

        // GET: BranchController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var branch = await _branchInfoServices.FindAsync(x => x.Id == id, x => x.CompanyInfo, x => x.Country, x => x.State, x => x.City, x => x.ZipCode);
            if(branch == null)
            {
                return NotFound();
            }
            return View(branch);
        }

        // GET: BranchController/Create
        public async Task <IActionResult> Create()
        {
            ViewData["CompanyInfoId"] = _companyInfoServices.Dropdown();
            ViewData["CountryId"]=_countryService.Dropdown();
            ViewData["StateId"]=_stateService.Dropdown();
            ViewData["City"]=_cityService.Dropdown();
            ViewData["ZipCodeId"] = _zipCodeService.Dropdown();
            return View();
        }

        // POST: BranchController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BranchInfo branchInfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _branchInfoServices.InsertAsync(branchInfo);
                    TempData["Successfull"] = "Branch Save Successfull";

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                throw;
            }
            ViewData["CompanyInfoId"] = _companyInfoServices.Dropdown();
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["City"] = _cityService.Dropdown();
            ViewData["ZipCodeId"]=_zipCodeService.Dropdown();
            return View(branchInfo);
        }

        // GET: BranchController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var branch = await _branchInfoServices.FindAsync(x => x.Id == id, x => x.CompanyInfo, x => x.Country, x => x.State, x => x.City, x => x.ZipCode);
            if (branch == null)
            {
                return NotFound();
            }
            ViewData["CompanyInfoId"] = _companyInfoServices.Dropdown();
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();
            ViewData["ZipCodeId"] = _zipCodeService.Dropdown();
            return View(branch);
        }

        // POST: BranchController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BranchInfo branchInfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Branch = await _branchInfoServices.FindAsync(branchInfo.Id);
                    Branch.BranceName = branchInfo.BranceName;
                    Branch.BranchAddress= branchInfo.BranchAddress;
                    Branch.CompanyInfoId = branchInfo.CompanyInfoId;
                    Branch.CountryId=branchInfo.CountryId;
                    Branch.StateId=branchInfo.StateId;
                    Branch.CityId=branchInfo.CityId;
                    Branch.ZipCodeId=branchInfo.ZipCodeId;
                    Branch.Email=branchInfo.Email;
                    Branch.ContactNumber = branchInfo.ContactNumber;

                    await _branchInfoServices.UpdateAsync(branchInfo);
                    TempData["successAlert"] = "Update Branch Successfully";

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            ViewData["CompanyInfoId"] = _companyInfoServices.Dropdown();
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["City"] = _cityService.Dropdown();
            ViewData["ZipCodeId"] = _zipCodeService.Dropdown();
            TempData["errorAlert"] = "Sorry Unable to update";
            return View(branchInfo);

        }

        // GET: BranchController/Delete/5
        public async Task <IActionResult> Delete(int id)
        {
            var branch = await _branchInfoServices.FindAsync(x => x.Id == id, x => x.CompanyInfo, x => x.Country, x => x.State, x => x.City,x=>x.ZipCode);
            if (branch == null)
            {
                return NotFound();
            }
            ViewData["CompanyInfoId"] = _companyInfoServices.Dropdown();
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["City"] = _cityService.Dropdown();
            ViewData["ZipCodeId"] = _zipCodeService.Dropdown();
            return View(branch);
        }

        // POST: BranchController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, BranchInfo branchInfo)
        {
           
                var branch = await _branchInfoServices.FindAsync(x => x.Id == id, x => x.CompanyInfo, x => x.Country, x => x.State, x => x.City,x=>x.ZipCode);
                if(branch != null)
                {
                    await _branchInfoServices.DeleteAsync(branch);
                    TempData["SuccessAlert"] = "Delect Branch Successfully";
                }
                TempData["errorAlert"] = "Operation failed.";
                return RedirectToAction(nameof(Index));
            
        }
    }
}
