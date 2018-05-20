using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAMS.Models;
using PAMS.DAL;

namespace PAMS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DAL.Login objDalLogin = new DAL.Login();
       
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Login objModelLogin)
        {
            int i = objDalLogin.CheckLogin(objModelLogin);
            if(i==1)
            {// ViewBag.message = "valid user";
              return  RedirectToAction("AdminHome");
            }
            else
            { ViewBag.message = "invalid user"; }
            return View();
        }

        public ActionResult AdminHome()
        {
            return View();
        }
    }
}