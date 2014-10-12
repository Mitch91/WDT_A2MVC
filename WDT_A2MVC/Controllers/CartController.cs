using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WDT_A2MVC.Models;

namespace WDT_A2MVC.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index(int id = -1)
        {
            if (Object.Equals(Session["User"], null))
            {
                Session["User"] = new User();
            }

            User u = (User)Session["User"];

            if (u.cart.numItems == 0)
            {
                ViewBag.message = "There are no items in your cart";
            }
            else
            {
                List<SelectListItem> catDropDown = new List<SelectListItem>();

                if (id == -1)
                {
                    ViewBag.products = u.cart.contents;
                    ViewBag.totalCost = u.cart.totalCost.ToString("c2");
                }
                else
                {
                    ViewBag.products = u.cart.GetProductsForCategory(id);
                    ViewBag.totalCost = u.cart.GetCostForCategory(id).ToString("c2");
                }

                catDropDown.Add(new SelectListItem { Value = "-1", Text = "All" });
                foreach (Category c in u.cart.GetCategories())
                {
                    catDropDown.Add(new SelectListItem
                    {
                        Value = String.Format("{0}", c.CategoryID),
                        Text = c.Title
                    });
                }

                ViewBag.categories = catDropDown;
            }
            return View();
        }

        public ActionResult ViewCategory(String category)
        {
            return RedirectToAction("Index", new { id = Int32.Parse(category) });
        }

        public String Add(int id, int quantity)
        {
            if (Object.Equals(Session["User"], null))
                Session["User"] = new User();

            Product p = DatabaseSystem.GetInstance().GetProductForId(id);
            if (!DatabaseSystem.GetInstance().Remove(id, quantity))
                return "Unable to add " + p.Title + " to your cart";

            ((User)Session["User"]).cart.Add(id, quantity);
            return "Added " + quantity + " of " + p.Title + " to your cart";
        }

        public String Remove(int id, int quantity)
        {
            Product p = DatabaseSystem.GetInstance().GetProductForId(id);
            if(!((User)Session["User"]).cart.Remove(id, quantity))
                return "Unable to remove " + p.Title + " from your cart";
            
            if (!DatabaseSystem.GetInstance().Add(id, quantity))
                return "Unable to remove " + p.Title + " from your cart";
                            
            return "Removed " + quantity + " of " + p.Title + " from your cart";
        }
    }
}