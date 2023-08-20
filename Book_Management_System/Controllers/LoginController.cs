using karad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace karad.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        UserEntities db=new UserEntities();
        [HttpGet]   
        public ActionResult SignIn()
        {
            ViewBag.Message = "";
            return View("SignIn");
        }

        [HttpPost]
        public ActionResult SignIn(User login)
        {
            List <User> loginToU=(from logins in db.Users where logins.email==login.email && logins.password==login.password select logins).ToList();
            if (loginToU.Count > 0)
            {
                if (loginToU[0].role == "admin")
                {
                    FormsAuthentication.SetAuthCookie(loginToU[0].username, false);
                    return Redirect("/Admin/Index");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(loginToU[0].username, false);
                    Session.Add("user_id", loginToU[0].user_id);
                    return Redirect("/Seller/Index");
                }
            }
            else
            {
                ViewBag.Message = "Credentials Invalid";
                return View();
            }
        }
    }
}