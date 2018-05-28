using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Description/About me";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Address and contant information";

            return View();
        }

        public ActionResult Portfolio()
        {
            ViewBag.Message = "My Portfolio";

            return View();
        }
    }
}