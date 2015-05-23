using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CouponsOnline.DataLayer
{
    public class CouponDataAccess
    {
        public static int CreateCoupon(string name, string desc, string orgprice, string discount, Business b, string datee, int maxNum, List<ListItem> interestt)
        {
            using (basicEntities be = new basicEntities())
            {
                Coupon cop = new Coupon();
                cop.Name = name;
                cop.Description = desc;
                cop.OriginalPrice = orgprice;
                cop.DiscountPrice = discount;
                cop.Business = b;
                //  cop.Interest = interestt;
                foreach (ListItem i in interestt)
                {
                    Interest t = FindInterest(b, i.Value);
                    be.Entry(t).State = System.Data.Entity.EntityState.Unchanged;
                    cop.Interests.Add(t);
                }
                cop.ExperationDate = datee;
                cop.MaxNum = maxNum;
                cop.AvarageRanking = "0";
                cop.Business_BusinessID = b.BusinessID;

                cop.Business = be.Businesses.Find(b.BusinessID);
                //  cop.InterestId = interestt.Id;
                be.Coupons.Add(cop);
                be.SaveChanges();

                return cop.Id;
            }
        }
        public static Interest FindInterest(Business Category, string desription)
        {
            using (basicEntities be = new basicEntities())
            {
                var bus = from b in be.Interests
                          where b.Description == desription & b.BusinessCategoriesId == Category.BusinessCategoriesId
                          select b;
                Interest Interests = bus.First();


                return Interests;

            }
        }

        internal static DataTable GetCouponsByCity(string city)
        {
            DataTable table = new DataTable();
            
            table.Columns.Add("Name",typeof(string));
            table.Columns.Add("Description",typeof(string));
            table.Columns.Add("Original Price",typeof(double));
            table.Columns.Add("New Price",typeof(double));
            table.Columns.Add("Business",typeof(string));
            table.Columns.Add("Location",typeof(string));
            table.Columns.Add("Rating",typeof(double));
            table.Columns.Add("MaxNum",typeof(int));
            table.Columns.Add("CoupinId", typeof(string));
  
            using (basicEntities be = new basicEntities())
            {
                 var bus = from b in be.Coupons
                          where b.Business.City.Name == city
                          select b;
                foreach (var item in bus)
                          
                {
                    DataRow dr = table.NewRow();
                    dr[0] = item.Name;
                    dr[1] = item.Description;
                    dr[2] = item.OriginalPrice;
                    dr[3] = item.DiscountPrice;
                    dr[4] = item.Business.Name;
         
                    dr[5] = item.Business.City.Name; ;
                    dr[6] = item.AvarageRanking; 
                    dr[7] = item.MaxNum;
                    dr[8] = item.Id;
                    table.Rows.Add(dr);
                }
            }
            return table;
        }

        internal static DataTable GetCouponsByBusniess(string Busniesss)
        {
            IQueryable<int> bus;
            using (basicEntities be = new basicEntities())
            {
                int i = Int32.Parse(Busniesss);
                bus = from b in be.Coupons
                          where b.Business.BusinessID == i
                          select b.Id;
            }

            return GetDataTable(bus.ToList());
        }

        internal static DataTable GetCouponsByInterest(List<ListItem> selectedInterests)
        {
            List<string> interests = new List<string>();
            foreach (var item in selectedInterests)
	        {
		        interests.Add(item.Text);
	        }
            List<int> bus = new List<int>();
            using (basicEntities be = new basicEntities())
            {
                foreach (var item in be.Coupons)
                {
                    foreach (var interest in item.Interests)
                    {
                        if (interests.Contains(interest.Description))
                        {
                            bus.Add(item.Id);
                            break;
                        }
                    }
                }
            }
            return GetDataTable(bus);
        }


        internal static DataTable GetDataTable(List<int> items)
        {
            using (basicEntities be = new basicEntities())
            {
                DataTable table = new DataTable();

                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("Description", typeof(string));
                table.Columns.Add("Original Price", typeof(double));
                table.Columns.Add("New Price", typeof(double));
                table.Columns.Add("Business", typeof(string));
                table.Columns.Add("Location", typeof(string));
                table.Columns.Add("Rating", typeof(double));
                table.Columns.Add("MaxNum", typeof(int));
                table.Columns.Add("CoupinId", typeof(string));

                foreach (var key in items)
                {
                    Coupon item = be.Coupons.Find(key);
                    DataRow dr = table.NewRow();
                    dr[0] = item.Name;
                    dr[1] = item.Description;
                    dr[2] = item.OriginalPrice;
                    dr[3] = item.DiscountPrice;
                    dr[4] = item.Business.Name;

                    dr[5] = item.Business.City.Name; ;
                    dr[6] = item.AvarageRanking;
                    dr[7] = item.MaxNum;
                    dr[8] = item.Id;
                    table.Rows.Add(dr);
                }
                return table;
            }          
        }
        
        internal static bool RemoveCoupon(string CoponId)
        {
            try
            {
                using (basicEntities be = new basicEntities())
                {
                   int coupinid = Int32.Parse(CoponId);

                   if (be.Coupons.Find(coupinid) != null)
                    {
                        Coupon cop = be.Coupons.Find(coupinid);
                       //removing course from busniess
                       // var deletedCourses = dbStudent.Courses.Except(student.Courses, cs => cs.CourseId).ToList<Course>();
                    
                       // deletedCourses.ForEach(cs => dbStudent.Courses.Remove(cs));
                        Business x = cop.Business;
                        var bus = (from b in be.Interests
                                   where b.Coupons.Contains(cop)
                                   select b);
                    ICollection<Interest> i = cop.Interests;
                       
                        foreach (Interest item in i)
                      {
                           item.Coupons.Remove(cop);
                     }
                       
                 
                        x.Coupons.Remove(cop);
                        be.Coupons.Remove(cop);
                        
                        be.SaveChanges();
                         return true;
                    }
                   
                    else
                    return false;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }

        

        internal static DataTable GetCouponsByGps(double coordinateX, double coordinateY)
        {
            throw new NotImplementedException();
        }
    }
}