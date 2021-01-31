using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Async;


namespace BugTracker.Controllers
{
    public class AccountsController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (username == "aman" && password == "iacsd")
            {
                return this.RedirectToAction("index", "home");
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }





     /*   [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult MagesticLogin(LoginViewModel model,string returnUrl)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }


            var result = await SignInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, shouldLockout: false);
            switch(result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid Login attempt");
                    return View(model);
            }
        }



        public ActionResult MajesticLogin(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        */
    }
}