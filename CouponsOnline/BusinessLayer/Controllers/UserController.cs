using CouponsOnline.DataLayer;
using CouponsOnline.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace CouponsOnline.BusinessLayer.Controllers
{
    public class UserController
    {
        public static List<string> ValidateRegisteration(string username,string password,string passwordval,
            string phone, string email, List<string> selectedInterests=null)
        {
            List<string> errors = new List<string>();

            //interest validation
            if (selectedInterests!=null && selectedInterests.Count == 0)
                errors.Add("You must select at least one interest.");


            //username validation
            if (username == "") errors.Add("You must enter a Username.");
            else if (UserDataAccess.GetUser(username) != null)
                errors.Add("Username is already taken.");

            //password validation
            if (password == "" && passwordval == "") errors.Add("You must enter a password.");
            else if (passwordval != password) errors.Add("Passwords do not match.");

            //phone validation
            Regex rxPhone = new Regex(@"^0\d([\d]{0,1})([-]{0,1})\d{7}$");
            if (phone == "") errors.Add("You must enter a phone number.");
            else if (!rxPhone.IsMatch(phone)) errors.Add("Enter phone number by the format: 0xx-xxxxxxx.");

            //email validation
            Regex rxEmail = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
            if (email == "") errors.Add("You must enter your email address.");
            else if (!rxEmail.IsMatch(email)) errors.Add("Email address is incorrect.");

            return errors;
        }
        public static List<string> ValidateInformationChanges(string phone, string 
            email, List<string> selectedInterests = null)
        {
            List<string> errors = new List<string>();
            if (selectedInterests != null && selectedInterests.Count == 0)
                errors.Add("You must select at least one interest.");
            else
            {
                using (basicEntities be = new basicEntities()){
                    foreach (var item in selectedInterests)
                    {
                        if (be.Interests.Find(int.Parse(item)) == null)
                        {
                            errors.Add("You odd interests.. Oo");
                            break;
                        }
                    }
                }
            }
            //phone validation
            Regex rxPhone = new Regex(@"^0\d([\d]{0,1})([-]{0,1})\d{7}$");
            if (phone == "") errors.Add("You must enter a phone number.");
            else if (!rxPhone.IsMatch(phone)) errors.Add("Enter phone number by the format: 0xx-xxxxxxx.");

            //email validation
            Regex rxEmail = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
            if (email == "") errors.Add("You must enter your email address.");
            else if (!rxEmail.IsMatch(email)) errors.Add("Email address is incorrect.");

            return errors;
        }
        
        public static bool CreateNewCustomer(string UserName, string Name, 
            string Password, string Phone, string Email,List<string> interests)
        {
            if (!UserDataAccess.AddUser(UserName, Name, Password, Phone, Email))
                return false;

            User user = UserDataAccess.GetUser(UserName);

            if (!user.AddAuthentication(UserType.Customer))
                return false;
            return UserDataAccess.UpdateInterestsToUser(UserName, interests);
        }
        public static bool CreateNewAdmin(string UserName, string Name, 
            string Password, string Phone, string Email)
        {
            if (!UserDataAccess.AddUser(UserName, Name, Password, Phone, Email))
                return false;
            User user = UserDataAccess.GetUser(UserName);
            return user.AddAuthentication(UserType.Admin);

        }
        public static bool CreateNewOwner(string UserName, string Name,
            string Password, string Phone, string Email)
        {
            if (!UserDataAccess.AddUser(UserName, Name, Password, Phone, Email))
                return false;
            User user = UserDataAccess.GetUser(UserName);
            return user.AddAuthentication(UserType.Owner);
        }

        //tested
        public static User GetUser(string userName)
        {
            return UserDataAccess.GetUser(userName);
        }

        public static Dictionary<User, UserType> GetAllUsers()
        {
            Dictionary<User, UserType> allUsers = new Dictionary<User, UserType>();
            using (basicEntities be = new basicEntities())
            {
                foreach (var item in be.Users)
                {
                    if (be.Users_Admin.Find(item.UserName)!=null)
                        allUsers.Add(item,UserType.Admin);
                    else if (be.Users_Customer.Find(item.UserName) != null)
                        allUsers.Add(item, UserType.Customer);
                    else if (be.Users_Owner.Find(item.UserName) != null)
                        allUsers.Add(item, UserType.Owner);                      
                }
            }
            return allUsers;
        }
    }
}