using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            return View();
        }


        public ActionResult GetText(string categories)
        {


            ViewBag.Text = categories;
            return View();
        }

     /*   public HtmlString test() {



            return " ";
        }
        */
    }
}