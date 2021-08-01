using System.Web.Mvc;
using collegemanagementASP.Context;
using System.Linq;

namespace collegemanagementASP.Controllers
{
    public class SignController : Controller
    {
        // GET: Sign

            [HttpGet]
        public ActionResult SignUp(int id = 0)
        {
            LoginSystem model = new LoginSystem();
            return View(model);
        }

        [HttpPost]
        public ActionResult SignUp(LoginSystem model)
        {
            using (collegemanagementEntities1 dbModel = new collegemanagementEntities1())
            {
                if (dbModel.LoginSystem.Any(x => x.UserName == model.UserName))
                {
                    ViewBag.DuplicateMessage = "Username already exist.";
                    return View("SignUp", model);
                }

                else if (dbModel.LoginSystem.Any(x => x.UserEmail == model.UserEmail))
                    {
                        ViewBag.DuplicateMessage1 = "UserEmail already exist.";
                        return View("SignUp", model);
                    }

                dbModel.LoginSystem.Add(model);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful.";
            return View("SignUp", new LoginSystem());
        }
    }
}