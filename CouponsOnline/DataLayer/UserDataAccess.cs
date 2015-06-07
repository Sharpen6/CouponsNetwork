using CouponsOnline.View;
//using CouponsOnline.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CouponsOnline.DataLayer
{
    public class UserDataAccess
    {
        // all tested
        public static UserType GetAuthentication(string username)
        {
            using (basicEntities be = new basicEntities())
            {
                if (be.Users_Admin.Find(username)!=null)
                    return UserType.Admin;
                if (be.Users_Owner.Find(username) != null)
                    return UserType.Owner;
                if (be.Users_Customer.Find(username) != null)
                    return UserType.Customer;
            }
            return UserType.Customer;
        }
        public static Users_Admin FindAdmin(string ad)
        {
            using (basicEntities be = new basicEntities())
            {
                Users_Admin admin = be.Users_Admin.Find(ad);              
                return admin;
            }            
        }
        public static Users_Owner FindOwner(string ow)
        {
            using (basicEntities be = new basicEntities())
            {
                Users_Owner owner = be.Users_Owner.Find(ow);
                be.Entry(owner).Collection(p => p.Businesses).Load();               
                return owner;
            }
        }
        public static Users_Customer FindCustomer(string cus)
        {
            using (basicEntities be = new basicEntities())
            {
                Users_Customer customer = be.Users_Customer.Find(cus);  
                be.Entry(customer).Collection(p => p.Interests).Load();
                return customer;
            }
        }
        public static User GetUser(string userName)
        {
            using (basicEntities be = new basicEntities())
            {
                User u = be.Users.Find(userName);
                return u;
            }
        }
        public static bool UpdateInfo(string UserName, string Name, string PhoneNum, string Email)
        {
            using (basicEntities be = new basicEntities())
            {
                User u = be.Users.Find(UserName);
                u.Name = Name;
                u.PhoneNum = PhoneNum;
                u.Email = Email;
                be.SaveChanges();
                return true;
            }

        }       
        public static bool UpdateInterestsToUser(string UserName, List<string> interests)
        {
            using (basicEntities be = new basicEntities())
            {
                be.Users_Customer.Find(UserName).Interests.Clear();
                foreach (var item in interests)
                {
                    
                    int interestId = int.Parse(item);
                    Interest i = be.Interests.Find(interestId);
                    if (i == null) continue;                   
                    //be.Entry(i).State = System.Data.Entity.EntityState.Unchanged;
                    be.Users_Customer.Find(UserName).Interests.Add(i);
                    be.SaveChanges();
                }
                 
            }
            return true;
        }
      
        public static bool ChangePassword(string UserName, string password)
        {
            using (basicEntities be = new basicEntities())
            {
                User u = be.Users.Find(UserName);
                u.Password = password;
                be.SaveChanges();
                return true;
            }

        }
        public static bool AddAuthentication(string UserName, UserType type)
        {
            using (basicEntities be = new basicEntities())
            {
                User baseUser = be.Users.Find(UserName);
                if (baseUser == null)
                    return false;
                switch (type)
                {
                    case UserType.Customer:
                        Users_Customer uc = new Users_Customer();
                        uc.User = baseUser;
                        uc.UserName = UserName;
                        be.Users_Customer.Add(uc);
                        break;
                    case UserType.Owner:
                        Users_Owner uo = new Users_Owner();
                        uo.User = baseUser;
                        uo.UserName = UserName;
                        be.Users_Owner.Add(uo);
                        break;
                    case UserType.Admin:
                        Users_Admin ua = new Users_Admin();
                        ua.User = baseUser;
                        ua.UserName = UserName;
                        be.Users_Admin.Add(ua);
                        break;
                    default:
                        break;
                }
                be.SaveChanges();
            }
            return true;
        }

        public static bool CheckCredentials(string username, string password)
        {
            using (basicEntities be = new basicEntities())
            {
                User a = be.Users.Find(username);
                if (a != null)
                    if (a.Password == password & a.Blocked == false)
                        return true;
            }
            return false;
        }
        public static bool AddUser(string UserName, string Name, string Password, string PhoneNum, string Email)
        {
            using (basicEntities be = new basicEntities())
            {
                //check for exsisting user with same username
                User newUser = be.Users.Find(UserName);
                if (newUser != null) return false;

                User u = new User();
                u.Name = Name;
                u.UserName = UserName;
                u.Password = Password;
                u.PhoneNum = PhoneNum;
                u.Email = Email;
                u.Blocked = false;
                be.Users.Add(u);
                be.SaveChanges();
                return true;
            }
        }
        public static bool RemoveUser(string UserName)
        {
            using (basicEntities be = new basicEntities())
            {
                be.Users.Find(UserName).Blocked = true;
                be.SaveChanges();
            }
            return true;
        }       
        
    }
}