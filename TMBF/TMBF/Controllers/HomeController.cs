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
            ViewBag.Message = "TMBF Telecom Solutions";

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
            if (usr.UserName == null || usr.UserName == "")
                goto Skip;
            if (ModelState.IsValid)
            {
                using (DAL.TelecomContext Context = new DAL.TelecomContext())
                {
                    var USER = Context.Users.Where(m => m.UserName.Equals(usr.UserName) && m.Password.Equals(usr.Password)).FirstOrDefault();
                    if (USER != null)
                    {
                        if (USER.role == TMBF.Models.User.Role.Customer)
                            Session["LoggedUser"] = Context.Customers.Where(m => m.ID.Equals(USER.ID)).FirstOrDefault();
                        else if (USER.role == TMBF.Models.User.Role.SalesRep)
                            Session["LoggedUser"] = Context.SalesReps.Where(m => m.ID.Equals(USER.ID)).FirstOrDefault();
                      
                        Session["MyMenu"] = null;
                        Session["Role"] = USER.role;
                        Session["UsrID"] = USER.ID;
                        Session["UsrName"] = USER.FirstName + " " + USER.LastName;
                        return RedirectToAction("Index");
                    }
                    
                }
            }
            Skip:
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