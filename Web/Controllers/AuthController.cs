using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Model;
using Service.Services;

namespace Web.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(VMLogin Credential)
        {
            msUserService userService = new msUserService();
            msUser user = userService.CheckUser(Credential.Email, Credential.Password);

            bool isUserExist = user != null ? true : false;

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
        public ActionResult CheckNIK()
        {
            return View();
        }
        public ActionResult CheckNIK(string nik)
        {
            msNIKService nikService = new msNIKService();

            return RedirectToAction("Login");
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(msUser newUSer)
        {
            msUserService userService = new msUserService();
            userService.Insert(newUSer);

            return RedirectToAction("Login");
        }
    }
}