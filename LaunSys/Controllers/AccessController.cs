using LaunSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vereyon.Web;
namespace LaunSys.Controllers
{
    public class AccessController : Controller
    {

        //-----------------------------Populate clients on the table----------------------------
        // GET: Users

        //public ActionResult Index()
        //{
        //    LaunSysDBEntities db = new LaunSysDBEntities();

        //    List<UsersViewModel> UsersList = db.tb_Users.Where(x => x.tb_Status.Status == true).Select(x => new UsersViewModel { Email = x.Email, Password = x.Password, Rolename = x.tb_Role.Rolename, Divisionname = x.tb_Division.Divisionname, Status = x.tb_Status.Status, Branchname = x.tb_Branch.Branchname, Deptname = x.tb_Department.Deptname, UserId = x.UserId }).ToList();
        //    ViewBag.ListOfUsers = UsersList;
        //    return View();
        //}

        // GET: Access
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LoginUser(UsersViewModel Model)
        {
            if (ModelState.IsValid)
            {
                LaunSysDBEntities db = new LaunSysDBEntities();



                var pass = System.Text.Encoding.UTF8.GetBytes(Model.Password);
               var encpass = Convert.ToBase64String(pass);

               tb_Users User = db.tb_Users.SingleOrDefault(x => x.Email == Model.Email && x.Password == encpass);

                 //tb_Users User = db.tb_Users.SingleOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);

                string result = "fail";
                if (User != null)
                {
                    Session["Email"] = User.Email;
                    Session["Password"] = User.Password;
                    Session["UserDepartment"] = User.tb_Department.Deptname;
                    Session["UserRole"] = User.tb_Role.Rolename;

                    if (User.RoleId == 1)
                    {
                        result = "Admin";
                        return RedirectToAction("Index", "Clients");
                    }
                    else if (User.RoleId == 2)
                    {
                        result = "Manager";
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Access");
                }
                if (result == "fail")
                {
                    FlashMessage.Confirmation("Invalid Login Details");
                    return RedirectToAction("Login", "Access");
                }
                //if (result == "Admin")
                //{
                //    return RedirectToAction("Index", "Clients");
                //}
                //if (result == "Manager")
                //{

                //}

                //return Json(result, JsonRequestBehavior.AllowGet);
            }
            return View();
        }


        public ActionResult LogOut()
        {
            //Session.Clear();
            Session.Abandon();
            Session.Contents.RemoveAll();
            return RedirectToAction("Login");
        }
    }
}