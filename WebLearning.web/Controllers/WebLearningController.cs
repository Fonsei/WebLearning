using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLearning.web.Models.User;
using WebLearning.logic;
using System.Web.Security;

namespace WebLearning.web.Controllers
{
    public class WebLearningController : Controller
    {
        [HttpGet]
        [Authorize]
        public ActionResult Dashboard()
        {
            Debug.WriteLine("GET - WebLearningController - Dashboard");
            Debug.Indent();

            Debug.Unindent();
            return View();
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
                if (UserVerwaltung.Login(model.Nickname, model.Email, model.Password))
                {
                    Debug.WriteLine("Erfolgreich Eingeloggt");
                    FormsAuthentication.SetAuthCookie(model.Email.ToUpper(), true);
                    return RedirectToAction("Dashboard","WebLearning");
                }
                else
                {
                    Debug.WriteLine("Registrierung Fehlgeschlagen");
                    ModelState.AddModelError("Password", "Ungültiger Benutzername/Passwort!");
                    return View();
                }
            }
            Debug.WriteLine("Registermodel ist nicht Vaild");
            Debug.Unindent();
            return View();
        }

        [HttpGet]
        public ActionResult Loggout()
        {
            Debug.WriteLine("POST - WebLearningController - Loggout");
            Debug.Indent();
            FormsAuthentication.SignOut();
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
                    return RedirectToAction("Home");
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