﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaunSys.Data.Model_Generated;
using System.Web;


namespace LaunSys.Common
{
    public class Controls
    {       
        LaunSysDBEntities db = new LaunSysDBEntities();


        //------------------------to set the data for the drop downn----------------
        //public string BranchList()
        //{
        //   return List<tb_Branch> BranchList = db.tb_Branch.ToList();

        //    //return BranchList;
        //}

        public List<tb_Branch> BranchList()
        {
            var AllBranches = db.tb_Branch.ToList();
            return AllBranches;
        }

        public void StatusList()
        {
            List<tb_Status> StatusList = db.tb_Status.ToList();
        }


        //public List<student> GetAllStudent(out List<course> ListOfCourse)
        //{
        //    var ListAllStudent = dbContext.Students.ToList();
        //    var ListOfCourse = dbContext.Students.Courses.ToList();

        //    return ListAllStudent;
        //}



    }
}
