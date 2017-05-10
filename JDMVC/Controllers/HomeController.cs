using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using JDMVC.Models;

namespace JDMVC.Controllers
{
    public class HomeController : Controller
    {
        JDEntities db = new JDEntities();
        Models.User u = new Models.User();
        UserLevels levels = new UserLevels();
        // GET: Home
        public ActionResult Index()
        {
            ViewData["Location"] = "江西";
            if (Session["users"] != null)
            {
                u = (User)Session["users"];
                ViewBag.toplogin = u.username;
                ViewBag.username = u.username;
                ViewBag.usernamelink = "/Users/home";
                ViewBag.login = levels.levels[u.accountlevel];
                ViewBag.reg = "退出";
                ViewBag.reglink = "/Users/SignOut";
            }
            else
            {
                ViewBag.toplogin = "登陆";
                ViewBag.topreg = "注册";
                ViewBag.username = "新用户";
                ViewBag.login = "登陆";
                ViewBag.loginlink = "/Users/Login";
                ViewBag.reg = "注册";
                ViewBag.reglink = "/Users/Reg";
            }
            return View();
        }
        public ActionResult Search(String word)
        {
            string html = "";

            var data = from t in db.Products
                       where t.name.ToLower().Contains(word.ToLower())
                       select t;
            if (data.Count() > 0)
            {
                foreach (var i in data)
                    html += "<li><a href='#'>" + i.name + "</a><li>";
                html += "<li style='text-align:right'><a class='close-helper'>关闭</a></li>";
                return Content(html);
            }
            else return Content("false");
        }
        private bool Compare(String a, String b, bool c)
        {
            int d = string.Compare(a, b, c);
            if (d == 1)
                return true;
            else
                return false;
        }
    }
}