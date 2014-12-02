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
        [CustomerR]
        [SalesRepR]
        public FileContentResult GenerateReport(string reportName, string month, string year, string format)
        {
            //Render the report            
            byte[] renderedBytes = null;
            switch (reportName)
	        {
	            case "CustomerBill":
		            renderedBytes = GenerateCustomerBillReportData(month, year, format);
		            break;
                case "SalesRepCommission":
                    renderedBytes = GenerateSalesRepCommissionData(month, year, format);
                    break;
	        }

            if (format == null)
            {
                return File(renderedBytes, "image/jpeg");
            }
            else if (format == "Excel")
            {
                return File(renderedBytes, "pdf");
            }
            else             {
                return File(renderedBytes, "image/jpeg");
            }
        }
        private byte[] GenerateCustomerBillReportData(string month, string year, string format)
        {
            if (month == null || year == null)
                return null;
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Report/rpCustomerBill.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "dsCustomerBill";
            /* Customer customer = new Customer();
            customer.ID = 6421234599;
            customer.PhoneNo = "6421234599"; */
            
            Customer customer = (Customer)Session["LoggedUser"];
            
            var customerBill = new ReportDAL().GetCustomerBill(customer.ID, int.Parse(month), int.Parse(year));

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
        [CustomerR]
        [SalesRepR]
        public ActionResult DownloadReport(string reportName, string month, string year, string format)
        {
             //Render the report            
            byte[] renderedBytes = null;
            switch (reportName)
            {
                case "CustomerBill":
                    renderedBytes = GenerateCustomerBillReportData(month, year, format);
                    break;
                case "SalesRepCommission":
                    renderedBytes = GenerateSalesRepCommissionData(month, year, format);
                    break;
            }
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
        public ActionResult SalesRepComissionReportViewer(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [SalesRepR]
        [ValidateAntiForgeryToken]
        public ViewResult SalesRepComissionReportViewer(SearchParameterModel searchParameterModel)
        {
            return View(searchParameterModel);
        }

        public byte[] GenerateSalesRepCommissionData(string month, string year, string format)
        {
            if (month == null || year == null)
                return null;
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Report/rpSalesRepComission.rdlc");

            SalesRep salesRep = new SalesRep();
            salesRep.ID = 1;

            var salesRepComission = new ReportDAL().GetSalesRepCommission(salesRep.ID, int.Parse(month), int.Parse(year));

            string period = string.Format("{0}/{1}", month, year);

            ReportParameter pSalesRepName = new ReportParameter("SalesRepName", string.Format("{0} {1}", salesRep.FirstName, salesRep.LastName));
            ReportParameter pSalesRepCommission = new ReportParameter("SalesRepCommission", string.Format("{0}", salesRepComission));
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
    }
}