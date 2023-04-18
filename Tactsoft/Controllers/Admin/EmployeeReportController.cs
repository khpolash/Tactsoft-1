using Microsoft.AspNetCore.Mvc;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class EmployeeReportController : Controller
    {
        private readonly IEmployeeReportService _employeeReportService;
        public EmployeeReportController(IEmployeeReportService employeeReportService)
        {
            this._employeeReportService = employeeReportService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PrintEmpDetails(long id)
        {
            var data = _employeeReportService.GetEmployeeRepoprtData(id);
            return View(data);
        }
        //public IActionResult DownloadInvoicePDF(long id)
        //{
        //    var result = _reportService.GetInvoiceReportData(id);
        //    var rpt = new ViewAsPdf();
        //    rpt.PageOrientation = Orientation.Portrait;
        //    rpt.CustomSwitches = footer;
        //    rpt.FileName = "Purchase_Invoice" + result.PurchaseViewModel.PurchaseCode + ".pdf";
        //    rpt.ViewName = "DownloadInvoicePDF";
        //    rpt.Model = result;
        //    return rpt;
        //}

        //public ActionResult ReportByDateRange()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult ReportByDateRange(DateTime startDate, DateTime endDate)
        //{
        //    ViewBag.StartDate = startDate.ToString("dd/MM/yyyy");
        //    ViewBag.EndDate = endDate.ToString("dd/MM/yyyy");
        //    var data = _reportService.ReportByDateRange(startDate, endDate);

        //    return View(data);
        //}


    }
}
