using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WDT_A2MVC.Models;

namespace WDT_A2MVC.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user){

            User u = DatabaseSystem.GetInstance().GetUserForId(user.Username);
            if(u != null)
            {
                ViewBag.error = "Username already taken";
                return View("Index");
            } else if(!DatabaseSystem.GetInstance().RegisterUser(user)){
                ViewBag.error = "Unable to save user information to database";
                return View("Index");
            }

            Session["User"] = user;
            return RedirectToAction("Index", "Products"); ;
        }
    }
}
