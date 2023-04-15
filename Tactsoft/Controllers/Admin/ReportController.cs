using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tactsoft.Data.DbDependencies;
using Tactsoft.Service.DbDependencies;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class ReportController : Controller
    {
        private readonly string footer = "--footer-center \"Printed on: " + DateTime.Now.Date.ToString("MM/dd/yyyy") + "  Page: [page]/[toPage]\"" + " --footer-line --footer-font-size \"10\" --footer-spacing 6 --footer-font-name \"calibri light\"";
        private readonly AppDbContext _appDbContext;
        private readonly ICompanyInfoServices _companyInfoServices;
        private readonly IGenderServices _genderServices;
        private readonly IBranchInfoServices _branchInfoService;
        private readonly IProjectService _projectService;
        private readonly IDepartmentService _departmentService;
        private readonly IMaritialStatusService _maritialStatusService;
        private readonly IReligionService _religionService;
        private readonly IEmploymentHistoryService _employmentHistoryService;
        private readonly IDesignationService _designationService;
        private readonly IFamilyMemberServices _familyMemberServices;
        private readonly IRelationShipService _relationshipService;
        private readonly IEmployeeReportService _employeeReportService;

        public ReportController(AppDbContext context, IEmployeeReportService employeeReportService,ICompanyInfoServices companyInfoServices, IGenderServices genderServices, IBranchInfoServices branchInfoServices, IProjectService projectService, IMaritialStatusService maritialStatusService, IReligionService religionService,
            IEmploymentHistoryService employmentHistoryService, IDesignationService designationService, IFamilyMemberServices familyMemberServices, IRelationShipService relationShipService, IDepartmentService departmentService)
        {
            this._appDbContext = context;
            this._companyInfoServices = companyInfoServices;
            this._genderServices = genderServices;
            this._branchInfoService = branchInfoServices;
            this._projectService = projectService;
            this._maritialStatusService = maritialStatusService;
            this._religionService = religionService;
            this._employmentHistoryService = employmentHistoryService;
            this._designationService = designationService;
            this._familyMemberServices = familyMemberServices;
            this._relationshipService = relationShipService;
            this._departmentService = departmentService;
            this._employeeReportService=employeeReportService;
        }
        public IActionResult PrintInvoice(long id)
        {
            var result = _employeeReportService.GetEmployeeReportData(id);
            return View(result);
        }

       

        
    }
}
