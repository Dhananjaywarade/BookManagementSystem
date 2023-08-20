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
    public class SellerController : Controller
    {
        // GET: Seller
        UserEntities db = new UserEntities();
        public ActionResult Index()
        {
            ViewBag.message="Welcome "+User.Identity.Name;
            int user_id = Convert.ToInt32(Session["user_id"]);
            List<book> books = (from book in db.books where book.user_id == user_id select book).ToList();

            return View("Index", books);    
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(book bookAdd)
        {
            db.books.Add(bookAdd);
            db.SaveChanges();
            return Redirect("/Seller/Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            book bookUpdate=(from bo in db.books where bo.book_id == id select bo).First();
            return View("Edit",bookUpdate);
        }

        [HttpPost]
        public ActionResult Edit(book bookUpdated)
        {
            book bookUpdate=(from bo in db.books where bo.book_id==bookUpdated.book_id select bo).First();
            bookUpdate.book_name=bookUpdated.book_name;
            bookUpdate.author=bookUpdated.author;
            bookUpdate.category=bookUpdated.category;
            bookUpdate.price=bookUpdated.price;
            db.SaveChanges();
            return Redirect("/Seller/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            book bookDelete=(from bo in db.books where bo.book_id==id select bo).First();
            db.books.Remove(bookDelete);
            db.SaveChanges();
            return Redirect("/Seller/Index");
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Seller/Index");

        }
    }
}