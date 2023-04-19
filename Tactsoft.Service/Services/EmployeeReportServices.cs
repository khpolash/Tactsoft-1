using Tactsoft.Service.Services;
using Tactsoft.Core.Entities.ViewModels.EmployeeVM;
using Tactsoft.Service.DbDependencies;

namespace Tactsoft.Service.Services
{
    public class EmployeeReportService : IEmployeeReportService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IEmployeeService _employeeService;
        private readonly IFamilyMemberServices _familyMemberServices;
        private readonly IEmploymentHistoryService _employmentHistoryService;

        public EmployeeReportService(AppDbContext context, IEmployeeService employeeService,
            IFamilyMemberServices familyMemberServices, IEmploymentHistoryService employmentHistoryService)
        {
            this._appDbContext = context;
            this._employeeService = employeeService;
            this._employmentHistoryService = employmentHistoryService;
            this._familyMemberServices = familyMemberServices;
        }

        public EmployeeReportViewModel GetEmployeeRepoprtData(long id)
        {
            EmployeeReportViewModel employeeRemporVM = new EmployeeReportViewModel();
            employeeRemporVM.EmpBasicInfoVM = GetEmpBasicData(id);
            employeeRemporVM.EmpFamilyMemberVM = GetEMpFamilyMemberData(id);
            employeeRemporVM.EmpHistoryVM = GetEmpEmployeementData(id);

            return employeeRemporVM;
        }

        private EmpHistoryVM GetEmpEmployeementData(long id)
        {
            return (from _empHistory in _appDbContext.EmploymentHistories
                    join _designation in _appDbContext.Designations
                    on _empHistory.DesignationId equals _designation.Id
                    where _empHistory.EmployeeId == id
                    select new EmpHistoryVM
                    {
                        Id = _empHistory.Id,
                        NameOfCompany = _empHistory.NameOfCompany,
                        Designation = _designation.DesignationName,
                        Salary = _empHistory.Salary,
                        JobFor = _empHistory.JobFor,
                        JobTo = _empHistory.JobTo,
                        ReasonForLeaving = _empHistory.ReasonForLeaving,

                    }).FirstOrDefault();

        }

        private EmpFamilyMemberVM GetEMpFamilyMemberData(long id)
        {
            return (from _empFamilyMember in _appDbContext.FamilyMembers
                    join _relation in _appDbContext.Relationships
                    on _empFamilyMember.RelationShipId equals _relation.Id
                    where _empFamilyMember.EmployeeId == id
                    select new EmpFamilyMemberVM
                    {
                        Id = _empFamilyMember.Id,
                        FamilyMemberName = _empFamilyMember.FamilyMemberName,
                        RelationShip = _relation.RelationShipName,
                        ContactNumber = _empFamilyMember.ContactNumber,
                        Address = _empFamilyMember.Address,

                    }).FirstOrDefault();
        }

        private EmpBasicInfoVM GetEmpBasicData(long id)
        {
            return (from _empBasic in _appDbContext.Employees
                    join _empBranch in _appDbContext.BranchInfos
                    on _empBasic.BrancehId equals _empBranch.Id
                    join _empCompany in _appDbContext.CompanyInfos
                    on _empBasic.CompanyId equals _empCompany.Id
                    join _empProject in _appDbContext.Projects
                    on _empBasic.CompanyId equals _empProject.Id
                    join _empreligion in _appDbContext.Religions
                    on _empBasic.ReligionId equals _empreligion.Id
                    join _empDepartment in _appDbContext.Departments
                    on _empBasic.DepartmentId equals _empDepartment.Id
                    join _empMaritial in _appDbContext.MaritialStatuses
                    on _empBasic.MaritialStatusId equals _empMaritial.Id
                   
                    where _empBasic.Id == id
                    select new EmpBasicInfoVM
                    {
                        Id = _empBasic.Id,
                        FullName = _empBasic.FirstName + " " + _empBasic.MiddleName + " " + _empBasic.LastName,
                        DateOfBirth = _empBasic.DateOfBirth,
                        
                        Branceh = _empBranch.BranceName,
                        Company = _empCompany.CompanyName,
                        Project = _empProject.ProjectName,
                        JoiningDate = _empBasic.JoiningDate,
                        Nationalaty = _empBasic.Nationalaty,
                        NID = _empBasic.NID,
                        Picture = _empBasic.Picture,
                        Religion = _empreligion.ReligionName,
                        Department = _empDepartment.DepartmentName,
                        MaritialStatus = _empMaritial.MaritialStatusName,

                    }).FirstOrDefault();
        }
    }
}
