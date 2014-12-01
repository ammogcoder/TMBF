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

namespace TMBF.Controllers
{
    [AdminR]
    public class CountryController : Controller
    {
        private TelecomContext db = new TelecomContext();

        // GET: /Country/
        public ActionResult Index()
        {
            return View(db.Countries.ToList());
        }

        // GET: /Country/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
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
