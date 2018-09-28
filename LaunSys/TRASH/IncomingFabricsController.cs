using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaunSys.Models;
using System.Data.Entity;

namespace LaunSys.Controllers
{
    public class IncomingFabricsController : Controller
    {
        // GET: IncomingFabrics
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (LaunSysDBEntities db = new LaunSysDBEntities())
            {
                List<tb_IncomingFabric> incFab = db.tb_IncomingFabric.ToList<tb_IncomingFabric>();
                return Json(new { data = incFab }, JsonRequestBehavior.AllowGet);    
             }
        }





        [HttpGet]
        public ActionResult AddOrEdit(int Id = 0)
        {

            if (Id==0)
                return View(new tb_IncomingFabric());
            else
            {
                using (LaunSysDBEntities db = new LaunSysDBEntities())
                {
                    return View(db.tb_IncomingFabric.Where(x =>x.Id==Id).FirstOrDefault<tb_IncomingFabric>());
                }
               
            }


        
        }

        [HttpPost]
        public ActionResult AddOrEdit(tb_IncomingFabric IncFab)
        {

            using (LaunSysDBEntities db = new LaunSysDBEntities())
            {
                if (IncFab.Id==0)
                {

                    db.tb_IncomingFabric.Add(IncFab);
                db.SaveChanges();
                return Json(new { success = true, message = "Incoming Fabric Saved Successfully" }, JsonRequestBehavior.AllowGet);
                 }
                else
                {
                    db.Entry(IncFab).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Incoming Fabric Updated Successfully" }, JsonRequestBehavior.AllowGet);

                }
            }
           
        }
    }
}