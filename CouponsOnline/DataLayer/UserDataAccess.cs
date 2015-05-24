using CouponsOnline.PresentationLayer;
//using CouponsOnline.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CouponsOnline.DataLayer
{
    public class UserDataAccess
    {
        public static bool isUserPassValid(string username,string password)
        {
            using (basicEntities be = new basicEntities())
            {
                User a = be.Users.Find(username);
                if (a!=null) 
                    if (a.Password==password)
                        return true;
            }
            return false;
        }
        public static bool AddUser(string UserName, string Name, string Password, int PhoneKidumet, int PhoneNum, string Email)
        {
            using (basicEntities be = new basicEntities())
            {
                //check for exsisting user with same username
                User sameKey = be.Users.Find(UserName);
                if (sameKey != null) return false;          

                User u = new User();
                u.Name = Name;
                u.UserName = UserName;
                u.Password = Password;
                u.PhoneKidomet = PhoneKidumet;
                u.PhoneNum = PhoneNum;
                u.Email = Email;
                be.Users.Add(u);
                be.SaveChanges();
                return true;
            }
        }
        public static bool AddAuthentication(string UserName,UserType type)
        {
            using (basicEntities be = new basicEntities())
            {
                User baseUser = be.Users.Find(UserName);
                if (baseUser==null) 
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

        internal static UserType GetAuthentication(string username)
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

        // Find Users in the system
        internal static Users_Admin FindAdmin(string ad)
        {
            using (basicEntities be = new basicEntities())
            {
                Users_Admin admin = be.Users_Admin.Find(ad);
                return admin;
            }            
        }
        internal static Users_Owner FindOwner(string ad)
        {
            using (basicEntities be = new basicEntities())
            {
                Users_Owner owner = be.Users_Owner.Find(ad);
                return owner;
            }
        }
        internal static Users_Customer FindCustomer(string ad)
        {
            using (basicEntities be = new basicEntities())
            {
                Users_Customer customer = be.Users_Customer.Find(ad);
                return customer;
            }
        }

        internal static Users_Owner FindOwnerBusiness(string selectedBusiness)
        {
            throw new NotImplementedException();
        }

        internal static User getUser(string ownerName)
        {
            using (basicEntities be = new basicEntities())
            {
                User u = be.Users.Find(ownerName);
                return u;
            }
        }

        internal static bool changeUser(string UserName, string Name, int PhoneKidumet, int PhoneNum, string Email)
        {
            using (basicEntities be = new basicEntities())
            {
                User u = be.Users.Find(UserName);
                u.Name = Name;
                u.PhoneKidomet = PhoneKidumet;
                u.PhoneNum = PhoneNum;
                u.Email = Email;
                be.SaveChanges();
                return true;
            }

        }

        internal static bool changeUser(string password,string UserName)
        {
            using (basicEntities be = new basicEntities())
            {
                User u = be.Users.Find(UserName);
                u.Password = password;
                be.SaveChanges();
                return true;
            }

        }

    }
}