using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyExcelTest;
using System.Data;
using TMBF.Business;
using System.Diagnostics;
using System.Collections;

namespace TMBF.Controllers
{
    [AdminR]
    public class RateController : Controller
    {
        //
        // GET: /Rate/
        public ActionResult FileUpload()
        {
            return View();
        }
        /// <summary>
        /// Inserts a Tab from an excel file, gets the service name from tabName
        /// </summary>
        /// <param name="dsRates"> DataSet with the information in the xls file</param>
        /// <param name="serviceInfo">format: Servicename_Sourcecountry</param>
        /// <param name="htCountry">DataSet with the countries and its ids</param>

        private int getOffPeekStartTime(string serviceinfo) {
            
            Hashtable htable = new Hashtable();
            htable["Spectra_USA"] = 1700;//17:00
            htable["Deluxe_USA"] = 1700;//17:00
            htable["VOIP_USA"] = 1700;//17:00
            htable["Budget_USA"] = 1700;//17:00
            htable["Premium_USA"] = 1700;//17:00

            htable["Spectra_Germany"] = 1900;
            htable["GACB_Germany"] = 1900;
            htable["Spectra_France"] = 1900;
            htable["GACB_France"] = 1900;
            htable["Spectra_Denmark"] = 1900;
            htable["GACB_Denmark"] = 1900;
            htable["Spectra_Italy"] = 1900;
            htable["GACB_Italy"] = 1900;

            htable["Spectra_England"] = 1800;
            htable["GACB_England"] = 1800;
            htable["Spectra_Netherlands"] = 1800;
            htable["GACB_Netherlands"] = 1800;

            htable["GACB_Spain"] = 1730;
            htable["GACB_Hungary"] = 1730;
            htable["GACB_Austria"] = 1730;

            int res;
            if (htable.ContainsKey(serviceinfo))
            {
                res = (int) htable[serviceinfo];
            }
            else
            {
                res = 2000;//TODO this country/service was not found!
            }
        
                
            return res;
        }
        private int getPeekStartTime(string serviceinfo) {
            Hashtable htable = new Hashtable();
            htable["Spectra_USA"] = 800;//08:00
            htable["Deluxe_USA"] = 800;
            htable["VOIP_USA"] = 800;
            htable["Budget_USA"] = 800;
            htable["Premium_USA"] = 800;

            htable["Spectra_Germany"] = 900;
            htable["GACB_Germany"] = 900;
            htable["Spectra_France"] = 900;
            htable["GACB_France"] = 900;
            htable["Spectra_Denmark"] = 900;
            htable["GACB_Denmark"] = 900;
            htable["Spectra_Italy"] = 900;
            htable["GACB_Italy"] = 900;

            htable["Spectra_England"] = 830;
            htable["GACB_England"] = 830;
            htable["Spectra_Netherlands"] = 830;
            htable["GACB_Netherlands"] = 830;

            htable["GACB_Spain"] = 900;
            htable["GACB_Hungary"] = 900;
            htable["GACB_Austria"] = 900;


            int res;
            if (htable.ContainsKey(serviceinfo))
            {
                res = (int)htable[serviceinfo];
            }
            else
            {
                res = 600;//TODO this country/service was not found!
            }

            return res;
        }
        
        private void insertSheet(DataSet dsRates, Hashtable htCountry, int tabIndex, DateTime startDate, DateTime endDate)
        {
            int destCountryID;
            float peekRate;
            float offPeekRate;
            int sourceCountryID = 0;

            DataTable table = dsRates.Tables[tabIndex];
            string[] words = table.TableName.Split('_');
            if (words.Length < 2) return;
            
            string serviceName = words[0];
            string sourceCountryName = words[1];
            int peekStartTime = getPeekStartTime(table.TableName);
            int offPeekStartTime = getOffPeekStartTime(table.TableName);

            try
            {
                 sourceCountryID = Int16.Parse( htCountry[sourceCountryName].ToString() );//constant acces time
            }
            catch (Exception)
            {
                Debug.WriteLine("Error looking up for country {0}", sourceCountryName);   
             
            }

            DataTable dt = initBatchTable();
            

            for (int i = 0; i < table.Rows.Count; i++)
			{
   			    DataRow tmp = table.Rows[ i ];
                DataRow newRow = dt.NewRow();
                destCountryID = Int16.Parse ( tmp[0].ToString() );
                peekRate = float.Parse( tmp[1].ToString() );
                offPeekRate = float.Parse(tmp[2].ToString());

                newRow["Name"] = serviceName;
                newRow["PeekRate"] = peekRate;
                newRow["OffPeekRate"] = offPeekRate;
                newRow["RateEffectiveDate"] = startDate;
                newRow["RateEndDate"] = endDate;
                newRow["PeekRateStartTime"] = peekStartTime;
                newRow["OffPeekRateStartTime"] = offPeekStartTime;
                newRow["DestinationCountry_ID"] = destCountryID;
                newRow["SourceCountry_ID"] = sourceCountryID;

                dt.Rows.Add( newRow );
                //ServicesDataAccess.insertService(serviceName, peekRate, offPeekRate, startDate, endDate, sourceCountryID, destCountryID);
			}
            ServicesDataAccess.insertServiceTable(dt);

        }

        private DataTable initBatchTable()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string) );
            dt.Columns.Add("PeekRate", typeof(float));
            dt.Columns.Add("OffPeekRate", typeof( float) );
            dt.Columns.Add("RateEffectiveDate", typeof(DateTime));
            dt.Columns.Add("RateEndDate", typeof(DateTime));
            dt.Columns.Add("PeekRateStartTime", typeof(int));
            dt.Columns.Add("OffPeekRateStartTime", typeof(int));
            dt.Columns.Add("DestinationCountry_ID", typeof( int ));
            dt.Columns.Add("SourceCountry_ID", typeof( int ));


            return dt;
            

        }

        /// <summary>
        /// converts the name of a spreadsheet into a date
        /// </summary>
        /// <param name="name">filename of the ratesheet to parse</param>
        private DateTime getDateFromName(string name)
        {
            string[] words = name.Split('_');
            string sYear = words[1].Substring(0, 4);
            string sMonth = words[1].Substring(4, 2);
            string sDay = words[1].Substring(6, 2);

            int year = Int16.Parse(sYear);
            int month = Int16.Parse(sMonth);
            int day = Int16.Parse(sDay);

            DateTime result = new DateTime(year,month,day);
            return result;
        }

        public Hashtable CreateIndexHashtable(DataTable table)
        {
            Hashtable indexTable = new Hashtable(255);

            for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
            {
                int id = (int)table.Rows[rowIndex]["ID"];
                string name = (string)table.Rows[rowIndex]["Name"];
                name = name.Trim();
                indexTable[name] = id;
            }
              return indexTable;
         }

        private bool insertToDatabase(string filename) {
            ExcelSheet sheet = new ExcelSheet();
            sheet.open(filename);

            if (!sheet.isOpen()) return false;
            DataSet dsCountry = CountriesDataAccess.getAsDataset();
            DataSet dsRates = sheet.getDataSet();
            DateTime startDate = getDateFromName(sheet.getName());
            DateTime endDate = new DateTime(3015,1,1);//FIXME hardcoded end date
            DateTime capDate = startDate.AddSeconds(-1);
            
            Hashtable hCountry = CreateIndexHashtable(dsCountry.Tables[0]);


            ServicesDataAccess.capEndDate(capDate);

            for (int i = 0; i < sheet.getTabCount(); i++)
            {
                int st = Environment.TickCount;
                insertSheet(dsRates, hCountry, i, startDate, endDate);
                Debug.WriteLine("insertSheet took:{0}ms", Environment.TickCount - st);
            }

            return true;
        }

        

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
                else if (file.ContentLength > 0)
                {
                    int MaxContentLength = 1024 * 1024 * 3; //3 MB
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
                        try
                        {
                            int st = Environment.TickCount;
                            bool inserted = insertToDatabase(path);
                            Debug.WriteLine("InsertToDatabase took:{0}ms", Environment.TickCount - st);
                            if (!inserted)
                            {
                                ModelState.AddModelError(String.Empty, "Error processing XLS file");
                            }
                            else
                            {
                                ModelState.AddModelError(String.Empty, "File uploaded successfully");
                            }
                        }
                        catch (Exception)
                        {
                            ModelState.AddModelError(String.Empty, "File is not a RATES file ");
                            
                        }
                        

                        
                    }
                }
            }
            return View();
        }
	}
}