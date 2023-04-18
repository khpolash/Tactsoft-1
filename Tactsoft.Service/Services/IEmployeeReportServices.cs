using Tactsoft.Core.Entities.ViewModels.EmployeeVM;

namespace Tactsoft.Service.Services
{
    public interface IEmployeeReportService
    {
        EmployeeReportViewModel GetEmployeeRepoprtData(long id);
    }
}
