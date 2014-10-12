using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WDT_A2MVC.Models
{
    public class Cart : IProductContainer
    {
        public List<Product> contents { get; private set; }

        public int numItems { get; private set; }

        public Decimal totalCost { get; private set; }

        public Cart()
        {
            contents = new List<Product>();
            numItems = 0;
            totalCost = 0;
        }

        public List<Product> GetProductsForCategory(int id)
        {
            List<Product> products = new List<Product>();

            foreach (Product p in contents)
                if (p.CategoryID == id)
                    products.Add(p);

            return products;
        }

        public Product GetProductForId(int id)
        {
            return contents.FirstOrDefault(p => p.ProductID == id);
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            foreach(Product p in contents){
                Category c = DatabaseSystem.GetInstance().
                    GetCategoryOfProduct(p.ProductID);
                if (!categories.Contains(c))
                    categories.Add(c);
            }

            return categories;
        }

        public Decimal GetCostForCategory(int id)
        {
            Decimal cost = 0;
            foreach (Product p in contents)
            {
                if (p.CategoryID == id)
                {
                    cost += p.Price;
                }
            }

            return cost;
        }

        public Boolean Add(int productId, int quantity)
        {
            Product product = contents.FirstOrDefault(p => p.ProductID == productId);
            if (Object.Equals(product, null))
            {
                product = DatabaseSystem.GetInstance().GetProductForId(productId);
                contents.Add(new Product(product.ProductID, product.CategoryID,
                product.Title, product.ShortDescription, product.LongDescription, product.Price, quantity));
                numItems++;
                totalCost += product.Price * quantity;
            }
            else
            {
                product.Quantity += quantity;
                totalCost += product.Price * quantity;
            }

            return true;
        }

        public Boolean Remove(int productId, int quantity)
        {

            Product product = contents.FirstOrDefault(p => p.ProductID == productId);
            if (Object.Equals(product, null) || product.Quantity < quantity)
                return false;

            product.Quantity -= quantity;
            if (product.Quantity == 0)
            {
                contents.Remove(product);
                numItems--;
            }

            totalCost -= product.Price * quantity;
            return true;
        }

        
    }
}