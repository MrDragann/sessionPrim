using Session.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Session.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Count"] == null)
            {
                Session["Count"] = 1;
            }
            else
            {
                int count = (int)Session["Count"];
                count++;
                Session["Count"] = count;
            }
            return View();
        }
        BookContext db = new BookContext();

        public ActionResult About()
        {
            
            return View(db.Books);
        }

        public ActionResult Contact()
        {
            
            return View();
        }

        public ActionResult MySession()
        {
            Session["SessionText"] = "Данный текст хранится в объекте Session";
            return View();
        }
        /// <summary>
        /// Редактирование модели
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditBook(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book = db.Books.Find(id);
            if (book != null)
            {
                return View(book);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("About");
        }
        /// <summary>
        /// Добавление модели
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return RedirectToAction("About");
        }
        /// <summary>
        /// Удаление модели
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Book b = db.Books.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Book b = db.Books.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Books.Remove(b);
            db.SaveChanges();
            return RedirectToAction("About");
        }

        /// <summary>
        /// Закрытие подключения
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}