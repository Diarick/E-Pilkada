using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Model;

namespace Web.Controllers
{
    public class AuthController : Controller
    {

        E_VotingEntities context = new E_VotingEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(VMLogin Credential)
        {
            bool isUserExist = context.msUsers.Any(f => f.Email == Credential.Email && f.Password == Credential.Password);
            msUser user = context.msUsers.FirstOrDefault(f => f.Email == Credential.Email && f.Password == Credential.Password);

            if (isUserExist)
            {
                FormsAuthentication.SetAuthCookie(user.Name, false);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Email atau kata sandi tidak sesuai");

            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(msUser newUSer)
        {
            context.msUsers.Add(newUSer);
            context.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}