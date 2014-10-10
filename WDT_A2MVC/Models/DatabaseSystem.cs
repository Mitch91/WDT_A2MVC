using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WDT_A2MVC.Models
{
    public class DatabaseSystem
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
            if (VerifyPassword(u.PasswordHash, /*SomeHashAlgorithm*/password))
                return u;
            else
                return null;
        }

        public User GetUserForId(String userName)
        {
            return (from user in dataBaseEntities.Users
                    where user.Username == userName
                    select user).ElementAt(0);
        }

        public Boolean VerifyPassword(String userPasswordHash, String inputHash){
            return String.Equals(userPasswordHash, inputHash);
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
            return (from c in dataBaseEntities.Categories
                    where c.CategoryID == categoryId
                    select c).ElementAt(0);
        }

        public Category GetCategoryOfProduct(int productId)
        {
            return GetProductForId(productId).Category;
        }

        public Product GetProductForId(int productId)
        {
            IQueryable<Product> product = from p in dataBaseEntities.Products
                           where p.ProductID == productId
                           select p;

            foreach (Product p in product)
                return p;

            return null;
        }
    }
}