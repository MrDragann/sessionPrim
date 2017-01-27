using System;
using System.Collections.Generic;
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

        public ActionResult About()
        {
            
            return View();
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
    }
}