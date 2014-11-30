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
using System.Diagnostics;
using PagedList;
 
namespace TMBF.Controllers
{
   
    public class CustomerController : Controller
    {
        private TelecomContext db = new TelecomContext();

        // GET: /Customer/
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.FNameSortParm = String.IsNullOrEmpty(sortOrder) ? "fname_desc" : "";
            ViewBag.PhoneSortParm = sortOrder == "asec" ? "phone_desc" : "asec";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            
            var customers = from c in db.Customers
                           select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(c => c.LastName.Contains(searchString)
                                       || c.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "fname_desc":
                    customers = customers.OrderByDescending(s => s.FirstName);
                    break; 
                case "asec":
                    customers = customers.OrderBy(s => s.ID);
                    break;
                case "phone_desc":
                    customers = customers.OrderByDescending(s => s.ID);
                    break;                             
                default:                
                    customers = customers.OrderBy(s => s.FirstName);
                    break;                                      
            }

            int pageSize = 2;
            int pageNumber = (page ?? 1);            

            customers = customers.Include(c => c.Country).Include(c => c.Service);
            return View(customers.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Customer/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: /Customer/Create
        public ActionResult Create()
        {
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name");
            ViewBag.ServiceID = new SelectList(db.Services, "ID", "Name");
            return View();
        }

        // POST: /Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,StreetAddress,City,State,ZipCode,CommisionForSalesRep,CountryID,ServiceID,SalesRepID,FirstName,LastName,Password")] Customer customer)
        {
            //Debug.WriteLine(customer.ID);
            if (customer.ID < 1000000000)
            {
                ViewBag.ErrorMessage = "Phone No.s are 10 digits long.";
                //Debug.WriteLine(customer.ID);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", customer.CountryID);
            ViewBag.ServiceID = new SelectList(db.Services, "ID", "Name", customer.ServiceID);
            return View(customer);
        }

        // GET: /Customer/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", customer.CountryID);
            ViewBag.ServiceID = new SelectList(db.Services, "ID", "Name", customer.ServiceID);
            return View(customer);
        }

        // POST: /Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,StreetAddress,City,State,ZipCode,CommisionForSalesRep,CountryID,ServiceID,SalesRepID,FirstName,LastName,Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", customer.CountryID);
            ViewBag.ServiceID = new SelectList(db.Services, "ID", "Name", customer.ServiceID);
            return View(customer);
        }

        // GET: /Customer/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: /Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
