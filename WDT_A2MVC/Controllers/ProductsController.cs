using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WDT_A2MVC.Models;

namespace WDT_A2MVC.Controllers
{
    public class ProductsController : Controller
    {

        public ActionResult Index(int categoryId = -1)
        {
            List<Product> products = DatabaseSystem.GetInstance().GetProductsForCategory(categoryId);
            Int32 i = 0;
            if (categoryId != -1)
            {
                Category category = DatabaseSystem.GetInstance().GetCategoryForId(categoryId);
                ViewBag.selectedText = category.Title;
                ViewBag.selectedValue = category.CategoryID;
            }
            else
            {
                ViewBag.selectedText = "All";
                ViewBag.selectedValue = "-1";
            }

            String jquery = @"<script>
                                var table = $('#table_id').DataTable();  
                                $(function () {  
                                    $('#table_id').on('click', 'i.delete', function (e) {   
                                        $.post('/Home/AddCart', { id: '4', }, function (result) {  
                                            bootbox.alert(result, function () {}); 
                                        });   
                                    }).on('click', 'i.edit', function (e) { }) 
                                });
                            </script>";

            StringBuilder html = new StringBuilder(@"<table id='table_id' class='table table-condensed table-bordered table-striped table-hover'> 
                                <thead><tr> 
                                    <th>Category</th>
                                    <th>Title</th>
                                    <th>Short Description</th>
                                    <th>Price</th>
                                    <th width='50'>&nbsp;</th>
                                </tr></thead>
                                <tbody>");

            foreach (Product product in products)
            {
                String categoryTitle = DatabaseSystem.GetInstance().GetCategoryOfProduct(product.ProductID).Title;
                html.Append(@"<tr id='" + ++i + @"' data-product_id='" + product.ProductID + @"'>
                                        <td>" + categoryTitle + @"</td>
                                        <td>" + product.Title + @"</td>
                                        <td>" + product.ShortDescription + @"</td>
                                        <td>" + product.Price + @"</td>
                                        <td>
                                            <span style='cursor:pointer'>
                                                <i class='fa fa-shopping-cart add'></i>
                                            </span>
                                        </td>
                                </tr>");
            }

            html.Append(@"</tbody></table>");

            ViewBag.table = jquery + html;

            return View();
        }
    }
}