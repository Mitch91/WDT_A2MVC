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
    public class ProductsController : Controller
    {
        public ActionResult Index(int id = -1)
        {
            List<Product> products = DatabaseSystem.GetInstance().GetProductsForCategory(id);
            List<SelectListItem> catDropDown = new List<SelectListItem>();

            catDropDown.Add(new SelectListItem { Value = "-1", Text = "All" });
            foreach(Category c in DatabaseSystem.GetInstance().GetCategories()){
                catDropDown.Add(new SelectListItem { 
                        Value = String.Format("{0}", c.CategoryID), 
                        Text = c.Title });
            }

            ViewBag.categories = catDropDown;
            ViewBag.products = products;
            

            return View();
        }

        public ActionResult ViewCategory(String category)
        {
            return RedirectToAction("Index", new { id = Int32.Parse(category) });
        }

        public ActionResult ProductView(int id = -1)
        {
            if (id == -1)
                return RedirectToAction("Index");
            ViewBag.product = DatabaseSystem.GetInstance().GetProductForId(id);
            return View();
        }
    }
}