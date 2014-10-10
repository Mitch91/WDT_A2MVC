using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WDT_A2MVC.Models
{
    public partial class Product
    {

        public Product() { }

        // If the user has added a product, it hasn't been added to the database yet and doesn't have a product Id, 
        // call this constructor
        public Product(Int32 categoryId, String title, String shortDescription, String longDescription, Decimal price)
        {
            this.CategoryID = categoryId;
            this.Title = title;
            this.ShortDescription = shortDescription;
            this.LongDescription = longDescription;
            this.Price = price;
        }

        //Product is being read from the database and has a product Id, use this constructor.
        public Product(Int32 productId, Int32 categoryId, String title, String shortDescription, String longDescription, Decimal price) :
            this(categoryId, title, shortDescription, longDescription, price)
        {
            this.ProductID = productId;
        }

        public Product(Int32 productId, Int32 categoryId, String title, String shortDescription, String longDescription, String imgUrl, Decimal price) :
            this(productId, categoryId, title, shortDescription, longDescription, price)
        {
            this.ImageUrl = imgUrl;
        }

        // For debugging. Delete before submitting.
        public override String ToString()
        {
            return String.Format("ProductId: {0}, CategoryId: {1}, Title: {2}, Short: {3}, Long: {4} ImgUrl: {5}, Price: {6}", 
                ProductID, CategoryID, Title, ShortDescription, LongDescription, ImageUrl, Price);
        }
    }
}