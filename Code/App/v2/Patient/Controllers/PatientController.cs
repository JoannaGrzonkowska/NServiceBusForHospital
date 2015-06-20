using BusinessLogic.Services;
using Patient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Patient.Controllers
{
    public class PatientController : Controller
    {
        private readonly IAccountService _accountService;


        public PatientController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }


        //LOGIN
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(PatientModel user)
        {
            if (ModelState.IsValid)
            {
                if (_accountService.IsValid(user.Name, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect.");
                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //REGISTER
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(PatientModel user)
        {
            if (ModelState.IsValid)
            {
                _accountService.AddUser(user.Name, user.Password, user.Age);
                RedirectToAction("Index", "Home");
            }

            return View();
        }





    }
}