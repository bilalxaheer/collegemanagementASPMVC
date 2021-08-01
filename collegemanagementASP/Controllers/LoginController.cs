using collegemanagementASP.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace collegemanagementASP.Controllers
{
    public class LoginController : Controller
    {
        //// GET: Login
        public ActionResult Login()
        {
            /*LoginSystem model = new LoginSystem();*/
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginSystem model)
        {
            using (collegemanagementEntities1 dbModel = new collegemanagementEntities1())
            {
                if (dbModel.LoginSystem.Any(x => x.UserName == model.UserName) && dbModel.LoginSystem.Any(x => x.UserPassword == model.UserPassword))
                {

                    ViewBag.SuccessMessage = "Login is successful";
                    return RedirectToAction("Index" , "Home");

                }


            }
            return View();
        }
    }
}