using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WDT_A2MVC.Models
{
    public interface IProductContainer
    {
        List<Product> GetProductsForCategory(int categoryId);

        List<Category> GetCategories();

        Product GetProductForId(int productId);

        Boolean Add(int productId, int quantity);

        Boolean Remove(int productId, int quantity);

    }
}