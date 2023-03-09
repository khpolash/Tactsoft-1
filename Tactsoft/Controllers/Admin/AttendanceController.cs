using Microsoft.AspNetCore.Mvc;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService _attendanceService;
        private readonly ICompanyInfoServices _companyInfoService;
        private readonly IEmployeeService _employeeService;
        public AttendanceController(IAttendanceService attendanceService, ICompanyInfoServices companyInfoService, IEmployeeService employeeService)
        {
            this._attendanceService = attendanceService;
            this._companyInfoService = companyInfoService;
            this._employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var Att = 
                      from C in _companyInfoService.All()
                      from E in _employeeService.All()
                      where E.CompanyInfo.CompanyName == C.CompanyName
                      select E;
            return View(Att);
        }
    }
}
