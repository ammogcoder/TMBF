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
        [AllowAnonymous]
        public ActionResult CustomerBillReportViewer(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ViewResult CustomerBillReportViewer(SearchParameterModel um)
        {
            return View(um);
        }

        public FileContentResult GenerateAndDisplayReport(string month, string year)
        {
            if (month == null || year == null)
                return null;
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Report/rpCustomerBill.rdlc");
            
            ReportDataSource reportDataSource = new ReportDataSource();
            //reportDataSource.Name = "dsCustomerBill";
            reportDataSource.Name = "dsColDTO";
            //ttt
            Customer customer = new Customer();
            customer.ID = 6421234599;
            customer.PhoneNo = "23234234";

            //IList<ColDTO> customerList = new ReportDAL().GetCustomerBill(customer.ID, int.Parse(month), int.Parse(year));
            var customerList = new ReportDAL().GetCustomerBill(customer.ID, int.Parse(month), int.Parse(year));

            reportDataSource.Value = customerList;
            localReport.DataSources.Add(reportDataSource);

            string period = string.Format("{0}/{1}", month, year);

            ReportParameter pCustomerName = new ReportParameter("CustomerName", string.Format("{0} {1}", customer.FirstName, customer.LastName) );
            ReportParameter pCustomerPhoneNo = new ReportParameter("CustomerPhoneNo", customer.PhoneNo); 
            ReportParameter pCustomerAddress = new ReportParameter("CustomerAddress", string.Format("{0} , {1},  {2}", customer.StreetAddress, customer.ZipCode, customer.State));
            ReportParameter pPeriod = new ReportParameter("Period", period);
            localReport.SetParameters(pCustomerName);
            localReport.SetParameters(pCustomerPhoneNo);
            localReport.SetParameters(pCustomerAddress);
            localReport.SetParameters(pPeriod);

            string reportType = "Image";
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
            renderedBytes = localReport.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            //Response.AddHeader("content-disposition", "attachment; filename=NorthWindCustomers." + fileNameExtension); 
  
                return File(renderedBytes, "image/jpeg");

        }    

    }
}