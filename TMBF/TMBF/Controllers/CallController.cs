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

        // GET: /Call/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Users, "ID", "UserName");
            return View();
        }

        // POST: /Call/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,CallDate,CallTime,Duration,ReceiverNo,CustomerID")] Call call)
        {
            if (ModelState.IsValid)
            {
                db.Calls.Add(call);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Users, "ID", "UserName", call.CustomerID);
            return View(call);
        }

        // GET: /Call/Edit/5
        public ActionResult Edit(long? id)
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
            ViewBag.CustomerID = new SelectList(db.Users, "ID", "UserName", call.CustomerID);
            return View(call);
        }

        // POST: /Call/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,CallDate,CallTime,Duration,ReceiverNo,CustomerID")] Call call)
        {
            if (ModelState.IsValid)
            {
                db.Entry(call).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Users, "ID", "UserName", call.CustomerID);
            return View(call);
        }

        // GET: /Call/Delete/5
        public ActionResult Delete(long? id)
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

        // POST: /Call/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Call call = db.Calls.Find(id);
            db.Calls.Remove(call);
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
