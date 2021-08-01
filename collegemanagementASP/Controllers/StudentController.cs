using collegemanagementASP.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace collegemanagementASP.Controllers
{

    public class StudentController : Controller
    {
        // GET: Student
        collegemanagementEntities1 dbObj = new collegemanagementEntities1();
        public ActionResult Student(newadmission obj)
        {
            if(obj != null)
                {

                return View(obj);
            }

                else{

                    return View();
                }
        }
        [HttpPost]
        public ActionResult AddStudent(newadmission model)

        {

            if (ModelState.IsValid)
            {
                newadmission Obj = new newadmission();
                //newadmission Obj = model;

                Obj.fname = model.fname;
                Obj.gname = model.gname;
                Obj.gender = model.gender;
                Obj.dob = model.dob;
                Obj.mobile = model.mobile;
                Obj.email = model.email;
                Obj.semster = model.semster;
                Obj.prog = model.prog;
                Obj.sname = model.sname;
                Obj.duration = model.duration;
                Obj.address = model.address;
                Obj.status = 1;
                dbObj.newadmission.Add(Obj);
                dbObj.SaveChanges();
            }
            ModelState.Clear();

            return View("Student");
        }

       public ActionResult StudentList()
        {
            var res = dbObj.newadmission.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = dbObj.newadmission.Where(x => x.ID == id).First();
            dbObj.newadmission.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.newadmission.ToList();

            return View("StudentList",list);
        }
    }
}