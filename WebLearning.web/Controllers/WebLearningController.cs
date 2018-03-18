using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLearning.web.Models.User;
using WebLearning.logic;
using System.Web.Security;
using WebLearning.web.Models;
using WebLearning.web.Models.Tasks;

namespace WebLearning.web.Controllers
{
    public class WebLearningController : Controller
    {
        public static Benutzer user;

        [HttpGet]
        [Authorize]
        public ActionResult Dashboard()
        {
            Debug.WriteLine("GET - WebLearningController - Dashboard");
            Debug.Indent();
            if(user == null)
                user = (Benutzer)Session["User"];

            DashboardModel model = new DashboardModel();
            model.IDUser = Convert.ToInt32(user.ID);
            model.Nickname = user.Nickname;

            model.Aktuelles = 2;
            model.Community = 13;
            model.Message = 0;
            model = TestDaten.LadeDaten(model,"fonsei1988@msn.com");
            if (model.Fach == null)
                model.Fach = new List<Subject>();

            Debug.Unindent();
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateSubject()
        {

            return Content("Hello Ajax", "text/plain");
            //return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            Debug.WriteLine("GET - WebLearningController - Login");
            Debug.Indent();

            Debug.Unindent();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUserModel model)
        {
            Debug.WriteLine("POST - WebLearningController - Login");
            Debug.Indent();


            if (ModelState.IsValid)
            {
                Debug.WriteLine("LoginUser ist Vaild");
                if (UserVerwaltung.Login(model.Email, model.Password))
                {
                    Benutzer user = UserVerwaltung.AktUser(model.Email);
                    Debug.WriteLine("Erfolgreich Eingeloggt");
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    //Response.Cookies.Add(new HttpCookie("Benutzer", model.Nickname.ToString()));
                    //Response.Cookies.Add(new HttpCookie("ID", model.ID.ToString()));

                    Session["User"] = user;
                    HttpCookie myCookie = new HttpCookie("WebLearning");
                    myCookie["ID"] = user.ID.ToString();
                    myCookie["Nickname"] = user.Nickname.ToString();
                    myCookie.Expires = DateTime.Now.AddDays(1d);
                    Response.Cookies.Add(myCookie);

                    return RedirectToAction("Dashboard","WebLearning");
                }
                else
                {
                    Debug.WriteLine("Login Fehlgeschlagen");
                    ModelState.AddModelError("Password", "Ungültiger Benutzername/Passwort!");
                    return View();
                }
            }
            Debug.WriteLine("Registermodel ist nicht Vaild");
            Debug.Unindent();
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Debug.WriteLine("POST - WebLearningController - Loggout");
            Debug.Indent();
            Session["User"] = null;
            HttpCookie myCookie = new HttpCookie("WebLearning");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
            user = null;
            Debug.WriteLine("Erfolgreich Ausgeloggt");
            Debug.Unindent();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            Debug.WriteLine("GET - WebLearningController - Register");
            Debug.Indent();

            Debug.Unindent();
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterUserModel model)
        {
            Debug.WriteLine("POST - WebLearningController - Register");
            Debug.Indent();
            if (ModelState.IsValid)
            {
                Debug.WriteLine("Registermodel ist Vaild");
                if (UserVerwaltung.Register(model.Nickname,model.Email,model.Password,model.PasswordRepeat,model.Username,model.Birthday))
                {
                    Debug.WriteLine("Erfolgreich Registriert");
                    return RedirectToAction("Login");
                }
                Debug.WriteLine("Registrierung Fehlgeschlagen");
                return View();
            }
            Debug.WriteLine("Registermodel ist nicht Vaild");
            Debug.Unindent();
            return View();
        }
    }
}