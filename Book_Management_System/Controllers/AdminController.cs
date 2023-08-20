using karad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace karad.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        UserEntities db=new UserEntities();
        
        public ActionResult Index()
        {
            ViewBag.message="Welcome "+User.Identity.Name;
            List <User> usersToShow=(from us in db.Users where us.role!="admin" select us).ToList();
           // List<User> usersToShow=db.Users.ToList().Where(u=>u.role!="admin").ToList();
            return View("Index",usersToShow);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            user.role = "seller";
            db.Users.Add(user);
            db.SaveChanges();
            return Redirect("/Admin/Index");

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            User empToDelete=(from us in db.Users where us.user_id==id select us).First();
            db.Users.Remove(empToDelete);
            db.SaveChanges();
            return Redirect("/Admin/Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            User userToUpdated=(from us in db.Users where us.user_id==id select us).First();
            return View("Edit", userToUpdated);
        }
        [HttpPost]
        public ActionResult Edit(User UserToUpdated)
        {
            User UserToUpdate = (from user in db.Users
                               where user.user_id == UserToUpdated.user_id
                               select user).First();
            UserToUpdate.username = UserToUpdated.username;
            UserToUpdate.email= UserToUpdated.email;
            UserToUpdate.mobile_no= UserToUpdated.mobile_no;
            UserToUpdate.password= UserToUpdated.password;
            db.SaveChanges();
            return Redirect("/Admin/Index");
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Admin/Index");

        }
    }
}