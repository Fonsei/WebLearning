using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLearning.web.Controllers
{
    public class WebLearningController : Controller
    {
        // GET: WebLearning
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Login(Login model)
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Register(Register model)
        //{
        //    return View();
        //}
    }
}