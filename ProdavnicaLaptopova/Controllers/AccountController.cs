using ProdavnicaLaptopova.Models;
using ProdavnicaLaptopova.Models.EFRepository;
using ProdavnicaLaptopova.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProdavnicaLaptopova.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private IAuthRepository authRepository = new AuthRepository();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }//Login()


        [HttpPost]
        public ActionResult Login(UserBO user)
        {
            if (authRepository.IsValid(user))
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return RedirectToAction("Index", "Laptop");
            }
            ModelState.AddModelError("", "Netacan username ili password");
            return View();
        }//Login()

        public ActionResult Register()
        {
            return View();
        }//Register()
        [HttpPost]
        public ActionResult Register(UserBO user)
        {
            authRepository.AddUser(user);
            return RedirectToAction("Login");
        }//Register()

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }//Logout()
    }
}