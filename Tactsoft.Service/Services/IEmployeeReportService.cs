using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities.ViewModels;

namespace Tactsoft.Service.Services
{
    public  interface IEmployeeReportService
    {
        EmployeeReportViewModel GetEmployeeReportData(long id);

    }
}
