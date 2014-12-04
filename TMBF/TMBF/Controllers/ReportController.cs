using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMBF.DAL;
using TMBF.Models;

namespace TMBF.Controllers
{
    public class ReportController : Controller
    {
        private TelecomContext db = new TelecomContext();
        [CustomerR]
        public ActionResult CustomerBillReportViewer(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [CustomerR]
        [ValidateAntiForgeryToken]
        public ViewResult CustomerBillReportViewer(SearchParameterModel searchParameterModel)
        {
            return View(searchParameterModel);
        }

        public FileContentResult GenerateReport(string reportName, string month, string year, string format, string serviceID, string countryID)
        {
            if (month == null || year == null)
                return null;
            serviceID = serviceID == null ? string.Empty : serviceID;
            countryID = countryID == null ? string.Empty : countryID;

            //Render the report            
            byte[] renderedBytes = null;
            switch (reportName)
            {
                case "CustomerBill":
                    renderedBytes = GenerateCustomerBillReportData(Convert.ToInt32(month), Convert.ToInt32(year), format);
                    break;
                case "SalesRepCommission":
                    renderedBytes = GenerateSalesRepCommissionData(Convert.ToInt32(month), Convert.ToInt32(year), format);
                    break;
                case "SummarySalesRepCommission":
                    renderedBytes = GenerateSummarySalesRepCommissionData(Convert.ToInt32(month), Convert.ToInt32(year), format);
                    break;
                case "TrafficSummary":
                    renderedBytes = GenerateTrafficSummaryData(Convert.ToInt32(month), Convert.ToInt32(year), format);
                    break;
                case "Rate":
                    renderedBytes = GenerateRateData(Convert.ToInt64(serviceID), Convert.ToInt64(countryID), Convert.ToInt32(month), Convert.ToInt32(year), format);
                    break;
            }
            if (renderedBytes == null)
                return null;
            if (format == null)
            {
                return File(renderedBytes, "image/jpeg");
            }
            else if (format == "Excel")
            {
                return File(renderedBytes, "pdf");
            }
            else
            {
                return File(renderedBytes, "image/jpeg");
            }
        }
        private byte[] GenerateCustomerBillReportData(int month, int year, string format)
        {
            if (month == 0 || year == 0)
                return null;
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Report/rpCustomerBill.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "dsCustomerBill";
            if (Session["LoggedUser"] == null || !(Session["LoggedUser"] is Customer))
                return null;

            Customer customer = (Customer)Session["LoggedUser"];

            var customerBill = new ReportDAL().GetCustomerBill(customer.ID, month, year);

            reportDataSource.Value = customerBill;
            localReport.DataSources.Add(reportDataSource);

            string period = string.Format("{0}/{1}", month, year);

            ReportParameter pCustomerName = new ReportParameter("CustomerName", string.Format("{0} {1}", customer.FirstName, customer.LastName));
            ReportParameter pCustomerPhoneNo = new ReportParameter("CustomerPhoneNo", customer.PhoneNo);
            ReportParameter pCustomerAddress = new ReportParameter("CustomerAddress", string.Format("{0} , {1},  {2}", customer.StreetAddress, customer.ZipCode, customer.State));
            ReportParameter pPeriod = new ReportParameter("Period", period);
            localReport.SetParameters(pCustomerName);
            localReport.SetParameters(pCustomerPhoneNo);
            localReport.SetParameters(pCustomerAddress);
            localReport.SetParameters(pPeriod);

            string mimeType;
            string encoding;
            string fileNameExtension;
            //The DeviceInfo settings should be changed based on the reportType            
            //http://msdn2.microsoft.com/en-us/library/ms155397.aspx            
            string deviceInfo = "<DeviceInfo>" +
                "  <OutputFormat>jpeg</OutputFormat>" +
                "  <PageWidth>8.5in</PageWidth>" +
                "  <PageHeight>11in</PageHeight>" +
                "  <MarginTop>0.5in</MarginTop>" +
                "  <MarginLeft>1in</MarginLeft>" +
                "  <MarginRight>1in</MarginRight>" +
                "  <MarginBottom>0.5in</MarginBottom>" +
                "</DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            //Render the report            
            renderedBytes = localReport.Render(format, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            return renderedBytes;
        }

        public ActionResult DownloadExcel(string reportName, string month, string year, string format, string serviceID, string countryID)
        {
            if (month == null || year == null)
                return null;
            serviceID = serviceID == null ? string.Empty : serviceID;
            countryID = countryID == null ? string.Empty : countryID;

            //Render the report            
            byte[] renderedBytes = null;
            switch (reportName)
            {
                case "CustomerBill":
                    renderedBytes = GenerateCustomerBillReportData(Convert.ToInt32(month), Convert.ToInt32(year), format);
                    break;
                case "SalesRepCommission":
                    renderedBytes = GenerateSalesRepCommissionData(Convert.ToInt32(month), Convert.ToInt32(year), format);
                    break;
                case "SummarySalesRepCommission":
                    renderedBytes = GenerateSummarySalesRepCommissionData(Convert.ToInt32(month), Convert.ToInt32(year), format);
                    break;
                case "TrafficSummary":
                    renderedBytes = GenerateTrafficSummaryData(Convert.ToInt32(month), Convert.ToInt32(year), format);
                    break;
                case "Rate":
                    renderedBytes = GenerateRateData(Convert.ToInt64(serviceID), Convert.ToInt64(countryID), Convert.ToInt32(month), Convert.ToInt32(year), format);
                    break;
            }
            if (renderedBytes == null)
                return null;
            if (format == null)
            {
                return File(renderedBytes, "image/jpeg");
            }
            else
            {
                string filename = string.Format("{0}.{1}", reportName, "xls");
                Response.ClearHeaders();
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
                Response.ContentType = "application/vnd.ms-excel";
                Response.BinaryWrite(renderedBytes);
                Response.Flush();
                Response.End();
                return View();
            }
        }
        [SalesRepR]
        public ActionResult SalesRepCommissionReportViewer(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [SalesRepR]
        [ValidateAntiForgeryToken]
        public ViewResult SalesRepCommissionReportViewer(SearchParameterModel searchParameterModel)
        {
            return View(searchParameterModel);
        }

        private byte[] GenerateSalesRepCommissionData(int month, int year, string format)
        {
            if (month == 0 || year == 0)
                return null;
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Report/rpSalesRepCommission.rdlc");

            if (Session["LoggedUser"] == null || !(Session["LoggedUser"] is SalesRep))
                return null;

            SalesRep salesRep = (SalesRep)Session["LoggedUser"];

            var salesRepCommission = new ReportDAL().GetSalesRepCommission(salesRep.ID, month, year);

            string period = string.Format("{0}/{1}", month, year);

            ReportParameter pSalesRepName = new ReportParameter("SalesRepName", string.Format("{0} {1}", salesRep.FirstName, salesRep.LastName));
            ReportParameter pSalesRepCommission = new ReportParameter("SalesRepCommission", String.Format("{0:0.00}", salesRepCommission));
            ReportParameter pPeriod = new ReportParameter("Period", period);
            localReport.SetParameters(pSalesRepName);
            localReport.SetParameters(pSalesRepCommission);
            localReport.SetParameters(pPeriod);

            string mimeType;
            string encoding;
            string fileNameExtension;
            //The DeviceInfo settings should be changed based on the reportType            
            //http://msdn2.microsoft.com/en-us/library/ms155397.aspx            
            string deviceInfo = "<DeviceInfo>" +
                "  <OutputFormat>jpeg</OutputFormat>" +
                "  <PageWidth>8.5in</PageWidth>" +
                "  <PageHeight>11in</PageHeight>" +
                "  <MarginTop>0.5in</MarginTop>" +
                "  <MarginLeft>1in</MarginLeft>" +
                "  <MarginRight>1in</MarginRight>" +
                "  <MarginBottom>0.5in</MarginBottom>" +
                "</DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            //Render the report            
            renderedBytes = localReport.Render(format, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            return renderedBytes;
        }

        [AdminR]
        public ActionResult SummarySalesRepCommissionReportViewer(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AdminR]
        [ValidateAntiForgeryToken]
        public ViewResult SummarySalesRepCommissionReportViewer(SearchParameterModel searchParameterModel)
        {
            return View(searchParameterModel);
        }
        private byte[] GenerateSummarySalesRepCommissionData(int month, int year, string format)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Report/rpSummarySalesRepCommission.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "dsSummarySalesRepCommission";

            var summarySalesRepCommission = new ReportDAL().GetSummarySalesRepCommission(month, year);

            reportDataSource.Value = summarySalesRepCommission;
            localReport.DataSources.Add(reportDataSource);

            string period = string.Format("{0}/{1}", month, year);

            ReportParameter pPeriod = new ReportParameter("Period", period);
            localReport.SetParameters(pPeriod);

            string mimeType;
            string encoding;
            string fileNameExtension;
            //The DeviceInfo settings should be changed based on the reportType            
            //http://msdn2.microsoft.com/en-us/library/ms155397.aspx            
            string deviceInfo = "<DeviceInfo>" +
                "  <OutputFormat>jpeg</OutputFormat>" +
                "  <PageWidth>8.5in</PageWidth>" +
                "  <PageHeight>11in</PageHeight>" +
                "  <MarginTop>0.5in</MarginTop>" +
                "  <MarginLeft>1in</MarginLeft>" +
                "  <MarginRight>1in</MarginRight>" +
                "  <MarginBottom>0.5in</MarginBottom>" +
                "</DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            //Render the report            
            renderedBytes = localReport.Render(format, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            return renderedBytes;
        }

        [AdminR]
        public ActionResult TrafficSummaryReportViewer(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AdminR]
        [ValidateAntiForgeryToken]
        public ViewResult TrafficSummaryReportViewer(SearchParameterModel searchParameterModel)
        {
            return View(searchParameterModel);
        }
        private byte[] GenerateTrafficSummaryData(int month, int year, string format)
        {
            if (month == 0 || year == 0)
                return null;
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Report/rpTrafficSummary.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "dsTrafficSummary";

            var trafficSummary = new ReportDAL().GetTrafficSummary(month, year);

            reportDataSource.Value = trafficSummary;
            localReport.DataSources.Add(reportDataSource);

            string period = string.Format("{0}/{1}", month, year);

            ReportParameter pPeriod = new ReportParameter("Period", period);
            localReport.SetParameters(pPeriod);

            string mimeType;
            string encoding;
            string fileNameExtension;
            //The DeviceInfo settings should be changed based on the reportType            
            //http://msdn2.microsoft.com/en-us/library/ms155397.aspx            
            string deviceInfo = "<DeviceInfo>" +
                "  <OutputFormat>jpeg</OutputFormat>" +
                "  <PageWidth>8.5in</PageWidth>" +
                "  <PageHeight>11in</PageHeight>" +
                "  <MarginTop>0.5in</MarginTop>" +
                "  <MarginLeft>1in</MarginLeft>" +
                "  <MarginRight>1in</MarginRight>" +
                "  <MarginBottom>0.5in</MarginBottom>" +
                "</DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            //Render the report            
            renderedBytes = localReport.Render(format, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            return renderedBytes;
        }
        [AdminR]
        public ActionResult RateReportViewer(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            ViewBag.CountryID = new SelectList(db.Countries.ToList(), "ID", "Name");

            IList<Service> serviceList = db.Services.GroupBy(i => i.Name).Select(g => g.FirstOrDefault()).ToList();
            ViewBag.ServiceID = new SelectList(serviceList, "ID", "Name");
            return View();
        }

        [HttpPost]
        [AdminR]
        [ValidateAntiForgeryToken]
        public ViewResult RateReportViewer(SearchParameterModel searchParameterModel)
        {
            ViewBag.CountryID = new SelectList(db.Countries.ToList(), "ID", "Name");

            IList<Service> serviceList = db.Services.GroupBy(i => i.Name).Select(g => g.FirstOrDefault()).ToList();
            ViewBag.ServiceID = new SelectList(serviceList, "ID", "Name");
            return View(searchParameterModel);
        }
        private byte[] GenerateRateData(long serviceID, long sourceCountryID, int month, int year, string format)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Report/rpRate.rdlc");

            string period = string.Format("{0}/{1}", month, year);
            Service service = db.Services.Where(s => s.ID == serviceID).FirstOrDefault();
            if (service == null)
                return null;
            Country country = db.Countries.Where(c => c.ID == sourceCountryID).FirstOrDefault();
            if (country == null)
                return null;

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "dsRate";

            var rate = new ReportDAL().GetRate(service.Name, sourceCountryID, month, year);

            reportDataSource.Value = rate;
            localReport.DataSources.Add(reportDataSource);



            ReportParameter pPeriod = new ReportParameter("Period", period);
            localReport.SetParameters(pPeriod);
            ReportParameter pServiceName = new ReportParameter("ServiceName", service.Name);
            localReport.SetParameters(pServiceName);
            ReportParameter pSourceCountryName = new ReportParameter("SourceCountryName", country.Name);
            localReport.SetParameters(pSourceCountryName);

            string mimeType;
            string encoding;
            string fileNameExtension;
            //The DeviceInfo settings should be changed based on the reportType            
            //http://msdn2.microsoft.com/en-us/library/ms155397.aspx            
            string deviceInfo = "<DeviceInfo>" +
                "  <OutputFormat>jpeg</OutputFormat>" +
                "  <PageWidth>8.5in</PageWidth>" +
                "  <PageHeight>11in</PageHeight>" +
                "  <MarginTop>0.5in</MarginTop>" +
                "  <MarginLeft>1in</MarginLeft>" +
                "  <MarginRight>1in</MarginRight>" +
                "  <MarginBottom>0.5in</MarginBottom>" +
                "</DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            //Render the report            
            renderedBytes = localReport.Render(format, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            return renderedBytes;
        }
    }
}