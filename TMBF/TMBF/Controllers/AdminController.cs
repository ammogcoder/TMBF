using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TMBF;
using TMBF.DAL;
using TMBF.Models;

namespace TMBF.Controllers
{
    [AdminR]
    public class AdminController : Controller
    {
        private TelecomContext db = new TelecomContext();

        // GET: /Admin/
        public ActionResult Index()
        {
            return View(db.Admins.ToList());
        }

        // GET: /Admin/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // GET: /Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="UserName,FirstName,LastName,Password")] Admin admin)
        {
            long min = 0;
            foreach (var sr in db.Admins)
            {
                if (min > sr.ID) min = sr.ID;
            }
            Debug.WriteLine(min);
            admin.ID = min-1;
            if (ModelState.IsValid)
            {
                admin.role = TMBF.Models.User.Role.Admin;
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        // GET: /Admin/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: /Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,UserName,FirstName,LastName,Password,role")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
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
