using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WDT_A2MVC.Models
{
    public class DatabaseSystem : IProductContainer
    {
        private static DatabaseSystem ds;

        private static DBEntities dataBaseEntities;

        private DatabaseSystem()
        {
             dataBaseEntities = new DBEntities();
        }
        public static DatabaseSystem GetInstance(){
            if (ds == null)
                ds = new DatabaseSystem();

            return ds;
        }

        public User AuthenticateUser(String userName, String password)
        {
            User u = GetUserForId(userName);
            if (VerifyPassword(u.Password, password)){
                u.loggedIn = true;
                return u;
            }
            else
                return null;
        }

        public User GetUserForId(String userName)
        {
            return dataBaseEntities.Users.
                FirstOrDefault(u => u.Username == userName);
        }

        public Boolean VerifyPassword(String password, String inputpassword){
            return String.Equals(password, inputpassword);
        }

        public List<Product> GetProductsForCategory(int categoryId = -1)
        {
            List<Product> productList = new List<Product>();


            if (categoryId == -1)
            {
                return dataBaseEntities.Products.ToList();
            }

            return GetCategoryForId(categoryId).Products.ToList();
        }

        public List<Category> GetCategories()
        {
            return dataBaseEntities.Categories.ToList();
        }

        public Category GetCategoryForId(int categoryId){
            return dataBaseEntities.Categories.
                FirstOrDefault(c => c.CategoryID == categoryId);
        }

        public Category GetCategoryOfProduct(int productId)
        {
            return GetProductForId(productId).Category;
        }

        public Product GetProductForId(int productId)
        {
            return dataBaseEntities.Products.
                FirstOrDefault(p => p.ProductID == productId);
        }

        public Boolean RegisterUser(User u)
        {
            try
            {
                dataBaseEntities.Users.Add(u);
                dataBaseEntities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }

        public Boolean Remove(int id, int quantity)
        {
            Product product = dataBaseEntities.Products.
                FirstOrDefault(p => p.ProductID == id);

            if (Object.Equals(product, null) || product.Quantity < quantity)
                return false;

            product.Quantity -= quantity;
            
            try
            {
                dataBaseEntities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

            
        }

        public Boolean Add(int id, int quantity)
        {
            Product product = dataBaseEntities.Products.
                FirstOrDefault(p => p.ProductID == id);
            
            if (Object.Equals(product, null))
                return false;

            product.Quantity += quantity;

            try
            {
                dataBaseEntities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}