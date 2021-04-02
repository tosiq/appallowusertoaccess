using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class StudentController : Controller
    {
        projectEntities dbp = new projectEntities();
        // GET: Student
        public ActionResult Fee_status()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Fee_status(Payment q,HttpPostedFileBase g)
        {
          string w=  Path.Combine(Server.MapPath("~/pay"), Path.GetFileName(g.FileName));
            g.SaveAs(w);
            q.upload = g.FileName;

            dbp.Payments.Add(q);
            dbp.SaveChanges();
            ModelState.Clear();
             
            return View();
        }
    }
}