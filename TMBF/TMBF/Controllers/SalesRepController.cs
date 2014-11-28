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
    public class SalesRepController : Controller
    {
        private TelecomContext db = new TelecomContext();

        // GET: /SalesRep/
        public ActionResult Index()
        {
            return View(db.SalesReps.ToList());
        }

        // GET: /SalesRep/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesRep salesrep = db.SalesReps.Find(id);
            if (salesrep == null)
            {
                return HttpNotFound();
            }
            return View(salesrep);
        }

        // GET: /SalesRep/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /SalesRep/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,FirstName,LastName,Password")] SalesRep salesrep)
        {
            if (ModelState.IsValid)
            {
                db.SalesReps.Add(salesrep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salesrep);
        }

        // GET: /SalesRep/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesRep salesrep = db.SalesReps.Find(id);
            if (salesrep == null)
            {
                return HttpNotFound();
            }
            return View(salesrep);
        }

        // POST: /SalesRep/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,FirstName,LastName,Password")] SalesRep salesrep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesrep).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salesrep);
        }

        // GET: /SalesRep/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesRep salesrep = db.SalesReps.Find(id);
            if (salesrep == null)
            {
                return HttpNotFound();
            }
            return View(salesrep);
        }

        // POST: /SalesRep/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            SalesRep salesrep = db.SalesReps.Find(id);
            db.SalesReps.Remove(salesrep);
            db.SaveChanges();
            return RedirectToAction("Index");
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
