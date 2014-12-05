using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TMBF.Models;
using TMBF.DAL;
using System.IO;
using MyExcelTest;
using System.Data.OleDb;
using System.Globalization;
using PagedList;

namespace TMBF.Controllers
{
   [AdminR]
    public class CallController : Controller
    {
        private TelecomContext db = new TelecomContext();

        // GET: /Call/
        public ActionResult Index(string sortOrder, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            var calls = from c in db.Calls
                         select c;
            switch (sortOrder)
            {
                default:
                    calls = calls.OrderBy(d => d.CallDate).ThenBy(t=>t.CallTime);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(calls.Include(c => c.Customer).ToPagedList(pageNumber, pageSize));
        }
       
        // GET: /Call/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Call call = db.Calls.Find(id);
            if (call == null)
            {
                return HttpNotFound();
            }
            return View(call);
        }

        public ActionResult ImportCalls()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ImportCalls(HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
                else if (file.ContentLength > 0)
                {
                    int MaxContentLength = 1024 * 1024 * 10; 
                    string[] AllowedFileExtensions = new string[] { ".xls", ".xlsx", ".png", ".pdf" };
                    if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                    {
                        ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                    }
                    else if (file.ContentLength > MaxContentLength)
                    {
                        ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                    }
                    else
                    {

                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Upload"), fileName);
                        file.SaveAs(path);
                        ModelState.Clear();
                        try { 
                        bool inserted = insertToDatabase(path);
                        if (!inserted)
                        {
                             ModelState.AddModelError(String.Empty,"Some Customers Are not Avaible in Customer Table so we didn't add their Calls Records");
                        }
                        else
                        {
                            ModelState.AddModelError(String.Empty,"Call File successfully Imported to DataBase");
                        }
                    }
                        catch (Exception exception)
                        {
                            ModelState.AddModelError(String.Empty, "File Is not Formatted As Calls File");
                        }

                    }
                }
            }
            return View();
        }
        private DateTime ReturnDate(String Date)
        {
            string[] date = Date.Split('/');
      
            return new DateTime(int.Parse(date[2]), int.Parse(date[0]), int.Parse(date[1]));
        }
        private bool FillToDataBase(DataRowCollection Data)
        {
            Boolean NoErrors = true;
            DataTable dt = initBatchTable();

            for (int i = 0; i < Data.Count && Data[i][0].ToString() != ""; i++)
            {
                DataRow newRow = dt.NewRow();
                newRow["CallDate"] = ReturnDate(Data[i][5].ToString());
                newRow["CallTime"] = Int32.Parse(Data[i][6].ToString());
                newRow["Duration"] = Int32.Parse(Data[i][4].ToString());
                newRow["ReceiverNo"] = Data[i][3].ToString();
                newRow["CustomerID"] = (long)((double)Data[i][2]);
                newRow["DestinationCountry_ID"] = Int32.Parse(Data[i][0].ToString());
                newRow["SourceCountry_ID"] = Int32.Parse(Data[i][1].ToString());
                //NoErrors = NoErrors && Business.CallsDataAccess.insertCalls(DateTime.FromOADate((double)Data[i][5]), (double)Data[i][6], (double)Data[i][4], Data[i][3].ToString(), (double)Data[i][2], (double)Data[i][0], (double)Data[i][1]);
                dt.Rows.Add(newRow);
            }

            Business.CallsDataAccess.insertCallTable(dt);
            return NoErrors;
        }
        private DataTable initBatchTable()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("CallDate", typeof(DateTime));
            dt.Columns.Add("CallTime", typeof(int));
            dt.Columns.Add("Duration", typeof(int));
            dt.Columns.Add("ReceiverNo", typeof(string));
            dt.Columns.Add("CustomerID", typeof(long));
            dt.Columns.Add("DestinationCountry_ID", typeof(int));
            dt.Columns.Add("SourceCountry_ID", typeof(int));


            return dt;


        }

        private bool FillToDataBaseOA(DataRowCollection Data)
        {
            Boolean NoErrors = true;
            DataTable dt = initBatchTable(); 

            for (int i = 0; i < Data.Count && Data[i][0].ToString()!=""; i++)
            {
                DataRow newRow = dt.NewRow();
                newRow["CallDate"] = DateTime.FromOADate((double)Data[i][5]);
                newRow["CallTime"] =  Int32.Parse(Data[i][6].ToString());
                newRow["Duration"] = Int32.Parse(Data[i][4].ToString());
                newRow["ReceiverNo"] = Data[i][3].ToString();
                newRow["CustomerID"] = (long)((double)Data[i][2]);
                newRow["DestinationCountry_ID"] = Int32.Parse(Data[i][0].ToString());
                newRow["SourceCountry_ID"] = Int32.Parse(Data[i][1].ToString());
                dt.Rows.Add(newRow);
                //NoErrors = NoErrors && Business.CallsDataAccess.insertCalls(DateTime.FromOADate((double)Data[i][5]), (double)Data[i][6], (double)Data[i][4], Data[i][3].ToString(), (double)Data[i][2], (double)Data[i][0], (double)Data[i][1]);
          
            }

            Business.CallsDataAccess.insertCallTable(dt);
           return NoErrors;
        }
        private bool insertToDatabase(string filename)
        {
            ExcelSheet sheet = new ExcelSheet();
            sheet.open(filename);

            if (!sheet.isOpen()) return false;

            DataRowCollection CallsData = sheet.getDataSet().Tables[0].Rows;
            try
            {
                DateTime.FromOADate((double)CallsData[0][5]);
                return FillToDataBaseOA(CallsData);
            }
            catch { return FillToDataBase(CallsData); }
     
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
