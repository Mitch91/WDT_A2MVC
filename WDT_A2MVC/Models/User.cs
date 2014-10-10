using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace WDT_A2MVC.Models
{
    public partial class User
    {

        public enum Origin {FROM_DB = 0, FROM_INPUT}

        public ShoppingCart cart { get; private set; }

        public Boolean loggedIn { get; private set; } 

        // Anonymous user who hasn't logged in
        public User()
        {
            loggedIn = false;
            cart = new ShoppingCart();
        }

        public User(String userName, String password, String firstName, String lastName, 
            String street, String suburb, String postcode, String state, Origin o) : this()
        {
            
            this.Username = userName;
            this.Firstname = firstName;
            this.Lastname = lastName;
            this.Street = street;
            this.Suburb = suburb;
            this.Postcode = postcode;
            this.State = state;

            if (o == Origin.FROM_INPUT)
            {
               this.PasswordHash = Convert.ToBase64String(
                   SHA1.Create().ComputeHash(
                   Encoding.UTF8.GetBytes(password)));
            }
            else
            {
                this.PasswordHash = password;
            }

            loggedIn = true;

        }
    }
}