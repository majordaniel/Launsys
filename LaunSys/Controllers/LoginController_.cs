using Login.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaunSys.Controllers
{
    public class LoginController : Controller
    {

        UserBusinessLogin UserBL = new UserBusinessLogin();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Login_()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User User)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                if (UserBL.CheckUserLogin(User)>0)
                {
                    message = "Success";
                }
                else
                {
                    message = "Username or Password is Incorrect";
                }
            }
            else
            {
                message = "All Fields are Required";
            }

            if (Request.IsAjaxRequest())
            {
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}