using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WDTAss2s3369678MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(String[] selectOpts)
        {

            string[] products = new string[3] {"Books", "Staves", "Potions"};

            ViewBag.selectOpts = products;
            return View();
        }


        public ActionResult Products(string selected)
        {
            ViewBag.selected = selected;

            String jquery = "<script>var table = $('#table_id').DataTable();  $(function () {  $('#table_id').on('click', 'i.delete', function (e) {   $.post('/Home/AddCart', { id: '4', }, function (result) {  bootbox.alert(result, function () {}); });   }).on('click', 'i.edit', function (e) { }) });</script>";

           // String jquery = "<script>var table = $('#table_id').DataTable(); $(function () { $('#table_id').on('click', 'i.delete', function (e) { var id = $(this).closest('tr').data('product_id'); alert(id);  bootbox.alert('da', function() {});  }).on('click', 'i.edit', function (e) { bootbox.alert('edit', function() {});  }) }); </script>";

            String html = "<table id='table_id' class='table table-condensed table-bordered table-striped table-hover'> <thead><tr> <th>Order ID</th><th>Category ID</th><th>Title</th><th>Short Description</th><th>Long Description</th><th>ImageURL</th><th>Price</th><th width='50'>&nbsp;</th></tr></thead><tbody><tr id='1' data-product_id='1'><td>a</td><td>a</td><td>a</td><td>a</td><td>a</td><td>bOOK</td><td>a</td><td><span style='cursor:pointer'><i class='fa fa-remove delete'></i></br><i class='fa fa-pencil-square-o edit'></i></span></td></tr><tr id='2' data-product_id='2'><td>a</td><td>a</td><td>a</td><td>a</td><td>a</td><td>Hello</td><td>a</td><td><span style='cursor:pointer'><i class='fa fa-remove delete'></i></br><i class='fa fa-pencil-square-o edit'></i></span></td></tr></tbody></table>";

           ViewBag.table = html + jquery;
         

            return View();
        }

        public String AddCart(string id) 
        {

            id = "aa";

            return id;
        
            
        
        }





    


    }
}