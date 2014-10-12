using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WDT_A2MVC.Models;

namespace WDT_A2MVC.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            if (Object.Equals(Session["User"], null) || !((User) Session["User"]).loggedIn)
                return RedirectToAction("LogIn");

            return View();
        }

        public ActionResult LogIn()
        {
            if (!Object.Equals(Session["User"], null) && ((User)Session["User"]).loggedIn)
                return RedirectToAction("Index");

            return View();
        }

        [HttpPost]
        public ActionResult LogIn(String username, String password)
        {   
            User u = DatabaseSystem.GetInstance().AuthenticateUser(username, password);
            
            if (!Object.Equals(u, null))
            {
                if (!Object.Equals(Session["User"], null))
                    u.ImportCart(((User)Session["User"]).cart);

                Session["User"] = u;
                return RedirectToAction("Index", "Products");
            }

            ViewBag.error = "Username or password is incorrect";
            return View();
        }

        public ActionResult LogOut()
        {
            foreach (Product p in ((User)Session["User"]).cart.contents)
            {
                DatabaseSystem.GetInstance().Add(p.ProductID, p.Quantity);
            }

            Session["User"] = null;
            return RedirectToAction("Index", "Products");
        }
    }
}