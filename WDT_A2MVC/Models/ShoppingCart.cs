using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WDT_A2MVC.Models
{
    public class ShoppingCart
    {
        public List<Product> contents { get; private set; }

        public int numItems { get; private set; }

        public Decimal totalCost { get; private set; }

        public ShoppingCart()
        {
            contents = new List<Product>();
            numItems = 0;
            totalCost = 0;
        }

        public void AddToCart(Product p)
        {
            contents.Add(p);
            numItems++;
            totalCost += p.Price;
        }

        public void RemoveFromCart(int productId)
        {
            foreach (Product p in contents)
            {
                if (p.ProductID == productId)
                {
                    contents.Remove(p);
                    numItems--;
                    totalCost -= p.Price;
                    break;
                }
            }
        }
    }
}