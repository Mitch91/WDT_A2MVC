using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WDT_A2MVC.Models;

namespace WDT_A2MVC.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Index()
        {
            User user = (User)Session["User"];
            if (!user.loggedIn)
                return RedirectToAction("LogIn", "Users");


            return View();
        }

        [HttpPost]
        public ActionResult Index(String ccnumber, String firstname, String lastname, 
            String street, String postcode, String state)
        {

            Boolean valid;

            int sum = 0, i = 0;
            while (i < ccnumber.Length) {
                int digit = Int32.Parse(ccnumber.ElementAt(i).ToString());
                switch(i++ % 2){
                    case 0:
                        sum += digit;
                        break;
                    case 1:
                        digit *= 2;
                        if(digit > 9)
                            sum += digit - 9;
                        else 
                            sum += digit;
                        break;
                }                    
            }

            valid = ((sum % 10) == 0);

            if (!valid)
            {
                ViewBag.error = "Invalid Credit card number";
                return View();
            }

            TempData["Firstname"] = firstname;
            TempData["Lastname"] = lastname;
            TempData["Street"] = street;
            TempData["Postcode"] = postcode;
            TempData["State"] = state;
            ((User)Session["User"]).cart.contents.CopyTo(ViewBag.cartContents);
            ((User)Session["User"]).cart.contents.Clear();

            return RedirectToAction("Summary");
        }

        public ActionResult Summary()
        {
            ((User)Session["User"]).cart.contents.CopyTo(ViewBag.cartContents);
            ((User)Session["User"]).cart.contents.Clear();
            ViewBag.Firstname = TempData["Firstname"];
            ViewBag.Lastname = TempData["Lastname"];
            ViewBag.Street = TempData["Street"];
            ViewBag.Postcode = TempData["Postcode"];
            ViewBag.State = TempData["State"];
            return View();
        } 
    }
}