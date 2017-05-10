using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JDMVC.Models;

namespace JDMVC.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Login()
        {
            return View();
        }
        Models.User u;
        JDEntities jd;
        [HttpPost]
        public ActionResult Login(String username, String password)
        {
            jd = new JDEntities();
            u = new Models.User();
            var data = from t in jd.Users
                       where t.username == username
                       where t.password == password
                       select t;
            if (data.Count() > 0)
            {
                u = (User)data.Single();
                Session["users"] = u;
                return Content("true");
            }
            else
                return Content("false");
        }
        public ActionResult SignOut()
        {
            Session["users"] = null;
            return RedirectToAction("Login", "Users");
        }
    }
}