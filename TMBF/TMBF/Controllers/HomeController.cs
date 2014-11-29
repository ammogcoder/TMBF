using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMBF.Models;

namespace TMBF.Controllers
{
    public class HomeController : Controller
    {
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
                        //Session["Role"]=
                        Session["UsrID"] = v.ID;
                        return RedirectToAction("Index");
                    }
                    else 
                        return View("Wrong Username / password");

                }
            }
            return View(usr);
        }
        ///////////////////////

    }
}