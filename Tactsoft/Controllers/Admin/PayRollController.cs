using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;

using Tactsoft.Core.ViewModels;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class PayRollController : Controller
    {
        private readonly IAllowanceDeductionServices _allowanceDeductionServices;
        private readonly ISalarySetupService _salarySetupService;
        private IEmployeeService _employeeService;
        public PayRollController(IAllowanceDeductionServices allowanceDeductionServices,ISalarySetupService salarySetupService,IEmployeeService employeeService)
        {
            this._allowanceDeductionServices = allowanceDeductionServices;
            this._salarySetupService = salarySetupService;
            this._employeeService = employeeService;
        }

    
        public async Task<IActionResult> AllowanceDeductionList()
        {
            var pay = await _allowanceDeductionServices.GetAllAsync();

            return View(pay);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AllowanceDeductionList(AllowanceDeduction model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id > 0)
                {
                    await _allowanceDeductionServices.UpdateAsync(model.Id, model);
                    return RedirectToAction("Index");
                }
                if (_allowanceDeductionServices.All().Any(x=>x.AllowanceDeductionName == model.AllowanceDeductionName))
                {
                    ModelState.AddModelError("AllowanceDeductionName", "Already Exists !");
                    return View( await _allowanceDeductionServices.GetAllAsync());

                }
                await _allowanceDeductionServices.InsertAsync(model);
                return RedirectToAction("Index");
            }
            return View(await _allowanceDeductionServices.GetAllAsync());
        }

       
        public ActionResult SalarySetup()
        {
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            return View(new SalarySetupModels());
        }


        [HttpPost]
        public IActionResult SalarySetup(SalarySetupModels model)
        {
            ViewData["EmployeeId"] = _employeeService.Dropdown();
            var salarySatups = _salarySetupService.All().Any(x => x.EmployeeId == model.EmployeeId);
            SalarySetupModels salarySetupModel = new SalarySetupModels();
            salarySetupModel.DepartmentId = model.DepartmentId;
            salarySetupModel.EmployeeId = model.EmployeeId;

            if (salarySatups)
            {
                var salarySatupList = _salarySetupService.All().Where(x => x.EmployeeId == model.EmployeeId).ToList();
                foreach (var item in salarySatupList)
                {
                    salarySetupModel.SalarySetupList.Add(new Core.ViewModels.SalarySetupList
                    {
                        AllowanceDeductionId = item.AllowanceDeductionId,
                        AllowanceDeductionName = _allowanceDeductionServices.NameById(item.AllowanceDeductionId),
                        SalarySetupId = item.Id,
                        IsPercent = item.IsPercent,
                        Value = item.Value
                    });
                }
                return View(salarySetupModel);
            }

            var ad = _allowanceDeductionServices.All();
            if (ad != null)
            {
                foreach (var item in ad)
                {
                    salarySetupModel.SalarySetupList.Add(new Core.ViewModels.SalarySetupList { AllowanceDeductionId = item.Id, AllowanceDeductionName = item.AllowanceDeductionName, AllowanceDeductionType = item.AllowanceDeductionType });
                }
                return View(salarySetupModel);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SaveSalarySetup(SalarySetupModels model)
        {
            if (model.SalarySetupList.Count() > 0)
            {
                foreach (var item in model.SalarySetupList)
                {
                    if (item.SalarySetupId == 0)
                    {
                        //save 
                        await _salarySetupService.InsertAsync(new SalarySetup
                        {
                            EmployeeId = model.EmployeeId,
                            AllowanceDeductionId = item.AllowanceDeductionId,
                            IsPercent = item.IsPercent,
                            Value = item.Value
                        });
                    }
                    else
                    {
                        // update 
                        var existingSalarySetup = await _salarySetupService.FindAsync(item.SalarySetupId);
                        if (existingSalarySetup != null)
                        {
                            existingSalarySetup.IsPercent = item.IsPercent;
                            existingSalarySetup.Value = item.Value;
                            existingSalarySetup.AllowanceDeductionId = item.AllowanceDeductionId;
                            await _salarySetupService.UpdateAsync(existingSalarySetup.Id, existingSalarySetup);
                        }
                    }
                }
            }
            return RedirectToAction("SalarySetup");
        }
    }
}
