using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities.ViewModels;
using Tactsoft.Service.DbDependencies;

namespace Tactsoft.Service.Services
{
    public class EmployeeReportService : IEmployeeReportService
    {
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

        public EmployeeReportService(AppDbContext context, ICompanyInfoServices companyInfoServices, IGenderServices genderServices, IBranchInfoServices branchInfoServices, IProjectService projectService, IMaritialStatusService maritialStatusService, IReligionService religionService,
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
        }
        public EmployeeReportViewModel GetEmployeeReportData(long id)
        {
            EmployeeReportViewModel employeeReportViewModel = new EmployeeReportViewModel();

            employeeReportViewModel.EmploymentHistoryViewModel = GetByEmploymentHistoryData(id);

            employeeReportViewModel.FamilyMemberViewModel = GetByFamilyMemberdata(id);
            employeeReportViewModel.EmployeeViewModel = GetByEmployee(id);
            return employeeReportViewModel;

        }
        private EmployeeViewModel GetByEmployee(long id)
        {
            return (from _Employee in _appDbContext.Employees
                    where _Employee.Id == id
                    select new EmployeeViewModel
                    {
                        Id = _Employee.Id,
                        FirstName = _Employee.FirstName,
                        MiddleName = _Employee.MiddleName,
                        LastName = _Employee.LastName,
                        DateOfBirth = _Employee.DateOfBirth,
                        NID = _Employee.NID,
                        Religion = _religionService.NameById(_Employee.ReligionId),
                        Nationalaty = _Employee.Nationalaty,
                        JoiningDate = _Employee.JoiningDate,
                        MaritialStatus = _maritialStatusService.NameById(_Employee.MaritialStatusId),
                        Gender = _genderServices.NameById(_Employee.GenderId),
                        Company = _companyInfoServices.NameById(_Employee.CompanyId),
                        Department = _departmentService.NameById(_Employee.DepartmentId),
                        Branceh = _branchInfoService.NameById(_Employee.BrancehId),
                        Project = _projectService.NameById(_Employee.ProjectId)

                    }).FirstOrDefault();
        }


        private EmploymentHistoryViewModel GetByEmploymentHistoryData(long? EmployeeId)
        {
            return (from _EmpH in _appDbContext.EmploymentHistories
                    where _EmpH.Id == EmployeeId
                    select new EmploymentHistoryViewModel
                    {
                        Id = _EmpH.Id,
                        NameOfCompany = _EmpH.NameOfCompany,
                        JobFor = _EmpH.JobFor,
                        JobTo = _EmpH.JobTo,
                        Salary = _EmpH.Salary,
                        ReasonForLeaving = _EmpH.ReasonForLeaving,
                        Designation = _designationService.NameById(_EmpH.Id)

                    })
                    .FirstOrDefault();
        }
        private FamilyMemberViewModel GetByFamilyMemberdata(long? EmployeeId)
        {
            return (from _Efm in _appDbContext.FamilyMembers
                    where _Efm.Id == EmployeeId
                    select new FamilyMemberViewModel
                    {
                        Id = _Efm.Id,
                        ContactNumber = _Efm.ContactNumber,

                    }).FirstOrDefault();
        }
    }
}
