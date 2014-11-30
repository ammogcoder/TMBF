using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TMBF.DAL;
using TMBF.Models;

namespace TMBF.Controllers
{
    public class HomeController : Controller
    {
        private TelecomContext db = new TelecomContext();

        public ActionResult Index()
        {
          
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Telecom Solutions";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us";

            return View();
        }
        /// <summary>
        /// Login Actions By Magdy
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User usr)
        {
            if (ModelState.IsValid)
            {
                using (DAL.TelecomContext Context = new DAL.TelecomContext())
                {
                    var v = Context.Users.Where(m => m.UserName.Equals(usr.UserName) && m.Password.Equals(usr.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        //if(v.role==TMBF.)
                        //      Session["LoggedUser"] = Context.Users.Where(m => m.UserName.Equals(usr.UserName) && m.Password.Equals(usr.Password)).FirstOrDefault();
                        //else if(v.role=="SalesRep")
                        //    Session["LoggedUser"] = Context.Users.Where(m => m.UserName.Equals(usr.UserName) && m.Password.Equals(usr.Password)).FirstOrDefault();
                        //Session["LoggedUser"] = v;
                        Session["MyMenu"] = null;
                        Session["Role"]=v.role;
                        Session["UsrID"] = v.ID;
                        Session["UsrName"] = v.FirstName + " " + v.LastName;
                        return RedirectToAction("Index");
                    }
                    
                }
            }
            this.ModelState.AddModelError(string.Empty, "The user name or password provided is incorrect.");
            return View(usr);
        }
        ///////////////////////
        public ActionResult Logout()
        {
            Session["LoggedUser"] = null;
            Session["MyMenu"] = null;
            Session["Role"] = null;
            Session["UsrID"] = null;
            Session["UsrName"] = null;
            return RedirectToAction("Index");
        }
    }
}