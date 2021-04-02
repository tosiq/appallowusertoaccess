using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        projectEntities db = new projectEntities();
        // GET: Home
        public ActionResult register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register(register12 p ,HttpPostedFileBase f)
        {
            string file2 = Path.Combine(Server.MapPath("~/img"), Path.GetFileName(f.FileName));
            f.SaveAs(file2);
            p.pic = f.FileName;
            db.register12.Add(p);
            db.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("login","home");
        }

        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(register12 p)
        {
           var s= db.register12.Where(a=>a.email==p.email && a.password==p.password).FirstOrDefault();
         
            if (s!=null)
            {

                if (s.status=="True")
                {//status if

             
                Session["email"] = s.email;
                Session["name"] = s.name;
                Session["picture"] = s.pic;
                Session["role"] = s.role;
                ModelState.Clear();
                return RedirectToAction("form1","Home");
                }//status if end
                else
                {
                    ViewBag.msg = "your status is still pending";
                    return View();
                }//status else
            }
            else
            {
                ViewBag.msg = "your login crediantial is wrong";
                return View();
            }
            
        }
        public ActionResult form1()
        {
            if (Session["email"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login", "Home");
            }

        }
        //public ActionResult form()
        //{
        //    if (Session["email"]!=null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("login", "Home");
        //    }
            
        //}

        public ActionResult logout()
        {
            Session["email"] = null;
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("login","Home");
        }
    }
}