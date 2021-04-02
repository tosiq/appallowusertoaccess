using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AdminController : Controller
    {
        projectEntities db5 = new projectEntities();
        
        // GET: Admin
        public ActionResult Report()
        {
            return View();
        }
        public ActionResult Student_add()
        {
            return View();
        }
        public ActionResult Teacher_add()
        {
            return View();
        }
        public ActionResult allow()
        {
            if (Session["email"] != null)
            {
                return View(db5.register12.ToList());
            }
            else
            {
                return RedirectToAction("login", "Home");
            }

          
        }
        public ActionResult alltrue(int id)
        {
          var olddata=  db5.register12.Where(a => a.id == id).FirstOrDefault();
            olddata.status = "True";
            db5.SaveChanges();
            return RedirectToAction("allow","Admin");
        }
        public ActionResult allfalse(int id)
        {
            var olddata = db5.register12.Where(a => a.id == id).FirstOrDefault();
            olddata.status = "False";
            db5.SaveChanges();
            return RedirectToAction("allow", "Admin");
        }
    }
}