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

        public Cart cart { get; private set; }

        public Boolean loggedIn { get; internal set; }

        // Anonymous user who hasn't logged in
        public User()
        {
            cart = new Cart();
            loggedIn = false;
        }

        public User(String userName, String password, String firstName, String lastName, 
            String street, String suburb, String postcode, String state) : this()
        {
            
            this.Username = userName;
            this.Firstname = firstName;
            this.Lastname = lastName;
            this.Street = street;
            this.Suburb = suburb;
            this.Postcode = postcode;
            this.State = state;
            this.Password = password;
            this.loggedIn = true;
        }

        public void ImportCart(Cart c)
        {
            this.cart = c;
        }
    }
}