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

namespace TMBF.Controllers
{
   [AdminR]
    public class CallController : Controller
    {
        private TelecomContext db = new TelecomContext();

        // GET: /Call/
        public ActionResult Index()
        {
            var calls = db.Calls.Include(c => c.Customer);
            return View(calls.ToList());
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
                        catch
                        {
                            ModelState.AddModelError(String.Empty, "File Is not Formatted As Calls File");
                        }

                    }
                }
            }
            return View();
        }


        private bool FillToDataBase(DataRowCollection Data)
        {
            Boolean NoErrors = true;
          
            for (int i = 0; i < Data.Count && Data[i][0].ToString()!=""; i++)
            {
                 
                //NoErrors=NoErrors&&Business.CallsDataAccess.insertCalls(DateTime.FromOADate((double)Data[i][5]), (double)Data[i][6], (double)Data[i][4], Data[i][3].ToString(), (double)Data[i][2], (double)Data[i][0], (double)Data[i][1]);
          
            }
           return NoErrors;
        }
        private bool insertToDatabase(string filename)
        {
            ExcelSheet sheet = new ExcelSheet();
            sheet.open(filename);

            if (!sheet.isOpen()) return false;

            DataRowCollection CallsData = sheet.getDataSet().Tables[0].Rows;
        
            return FillToDataBase(CallsData);
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
