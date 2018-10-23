using LaunSys.Data.Model_Generated;
using LaunSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaunSys.Controllers
{
    public class UsersController : Controller
    {
        //-----------------------------Populate clients on the table----------------------------
        // GET: Users
        public ActionResult Index()
        {
            LaunSysDBEntities db = new LaunSysDBEntities();

            List<tb_Role> RoleList = db.tb_Role.ToList();
            ViewBag.VRoleLists = new SelectList(RoleList, "RoleId", "Rolename");

            List<tb_Division> DivisionList = db.tb_Division.ToList();
            ViewBag.VDivisionLists = new SelectList(DivisionList, "DivisionId", "Divisionname");

            List<tb_Branch> BranchList = db.tb_Branch.ToList();
            ViewBag.VBranchLists = new SelectList(BranchList, "BranchId", "Branchname");

            List<tb_Department> DeptList = db.tb_Department.ToList();
            ViewBag.VDeptLists = new SelectList(DeptList, "DeptId", "Deptname");

            List<tb_Status> StatusList = db.tb_Status.ToList();
            ViewBag.VStatusLists = new SelectList(StatusList, "StatusId", "Status");

            List<UsersViewModel> UsersList = db.tb_Users.Where(x => x.tb_Status.Status == true).Select(x => new UsersViewModel { Email = x.Email, Password = x.Password, Rolename = x.tb_Role.Rolename, Divisionname = x.tb_Division.Divisionname, Status=x.tb_Status.Status, Branchname = x.tb_Branch.Branchname, Deptname = x.tb_Department.Deptname, UserId =x.UserId}).ToList();

            ViewBag.ListOfUsers = UsersList;



            return View();
        }

        //-----------------------------to get active User ID----------------------------
        [HttpPost]
        public ActionResult Index(UsersViewModel Model)
        {

            try
            {
                //if (ModelState.IsValid == true)
                //{
                LaunSysDBEntities db = new LaunSysDBEntities();
                //------------------------To populate the drop down lists---------------------------

                List<tb_Role> RoleList = db.tb_Role.ToList();
                ViewBag.VRoleLists = new SelectList(RoleList, "RoleId", "Rolename");

                List<tb_Division> DivisionList = db.tb_Division.ToList();
                ViewBag.VDivisionLists = new SelectList(DivisionList, "DivisionId", "Divisionname");

                List<tb_Branch> BranchList = db.tb_Branch.ToList();
                ViewBag.VBranchLists = new SelectList(BranchList, "BranchId", "Branchname");

                List<tb_Department> DeptList = db.tb_Department.ToList();
                ViewBag.VDeptLists = new SelectList(DeptList, "DeptId", "Deptname");

                List<tb_Status> StatusList = db.tb_Status.ToList();
                ViewBag.VStatusLists = new SelectList(StatusList, "StatusId", "Status");
                //----------------------------------------------------------------------------------



                if (Model.UserId > 0)
                {
                    //UPDATE EXISTING RECORD
                    tb_Users Users = db.tb_Users.SingleOrDefault(x => x.UserId == Model.UserId && x.tb_Status.Status == true);

                    Users.UserId = Model.UserId;
                    Users.Email = Model.Email;
                    Users.Password = Model.Password;
                    Users.RoleId = Model.RoleId;
                    Users.DivisionId = Model.DivisionId;
                    Users.BranchId = Model.BranchId;
                    Users.DeptId = Model.DeptId;
                    Users.StatusId = Model.StatusId;
                    db.SaveChanges();
                }

                else
                {
                    //INSERT NEW RECORD
                    tb_Users Users = new tb_Users();
                    Users.UserId = Model.UserId;
                    Users.Email = Model.Email;

                    

                         var pass = System.Text.Encoding.UTF8.GetBytes(Model.Password);
                    Users.Password = Convert.ToBase64String(pass);

                   // Users.Password = Model.Password;

                    Users.RoleId = Model.RoleId;
                    Users.DivisionId = Model.DivisionId;
                    Users.BranchId = Model.BranchId;
                    Users.DeptId = Model.DeptId;
                    Users.StatusId = Model.StatusId;
                  


                    db.tb_Users.Add(Users);
                    db.SaveChanges();
                }
                return View(Model);
                //}

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //-----------------------------Delete User----------------------------
        public JsonResult DeleteUser(int UserId)
        {
            LaunSysDBEntities db = new LaunSysDBEntities();
            bool result = false;
            tb_Users User = db.tb_Users.SingleOrDefault(x => x.tb_Status.Status == true && x.UserId == UserId);

            if (User != null)
            {
                //set the customer id to true, there fore hide it from the table\
                User.tb_Status.Status = false;
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        //-----------------------------to view User details individually----------------------------
        public ActionResult ViewUser(int UserId)
        {
            LaunSysDBEntities db = new LaunSysDBEntities();

            List<UsersViewModel> UserDetail = db.tb_Users.Where(x => x.tb_Status.Status == true && x.UserId == UserId).Select(x => new UsersViewModel { Email = x.Email, Password = x.Password, Rolename = x.tb_Role.Rolename, Divisionname = x.tb_Division.Divisionname, Status = x.tb_Status.Status, Branchname = x.tb_Branch.Branchname, Deptname = x.tb_Department.Deptname, UserId = x.UserId }).ToList();
          
            ViewBag.SingleUserDetail = UserDetail;


            return PartialView("SingleUserView");

        }

        //-----------------------------Add/Edit----------------------------
        public ActionResult AddEdit(int UserId)
        {
            LaunSysDBEntities db = new LaunSysDBEntities();

            List<tb_Role> RoleList = db.tb_Role.ToList();
            ViewBag.VRoleLists = new SelectList(RoleList, "RoleId", "Rolename");

            List<tb_Division> DivisionList = db.tb_Division.ToList();
            ViewBag.VDivisionLists = new SelectList(DivisionList, "DivisionId", "Divisionname");

            List<tb_Branch> BranchList = db.tb_Branch.ToList();
            ViewBag.VBranchLists = new SelectList(BranchList, "BranchId", "Branchname");

            List<tb_Department> DeptList = db.tb_Department.ToList();
            ViewBag.VDeptLists = new SelectList(DeptList, "DeptId", "Deptname");

            List<tb_Status> StatusList = db.tb_Status.ToList();
            ViewBag.VStatusLists = new SelectList(StatusList, "StatusId", "Status");

            UsersViewModel Model = new UsersViewModel();

            if (UserId > 0)
            {
                tb_Users Users = db.tb_Users.SingleOrDefault(x => x.UserId == UserId && x.tb_Status.Status == true);
                Model.UserId = Users.UserId;
                Model.Email = Users.Email;
                Model.Password = Users.Password;
                Model.RoleId = Users.RoleId;
                Model.DivisionId = Users.DivisionId;
                Model.BranchId = Users.BranchId;
                Model.DeptId = Users.DeptId;
                Model.StatusId = Users.StatusId;
            }


            return PartialView("AddEditViewPartialView", Model);

        }


    }
}