using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WDT_A2MVC;

namespace WDT_A2MVC.Models
{
    public partial class Category
    {
        public Category(Int32 categoryId, String title, String imgUrl)
        {
            this.CategoryID = categoryId;
            this.Title = title;
            this.ImageUrl = imgUrl;
        }

        // For debugging
        public override String ToString()
        {
            return String.Format("Title: {0}, CategoryId: {1}, ImgUrl: {2}", CategoryID, Title, ImageUrl);
        }
    }
}