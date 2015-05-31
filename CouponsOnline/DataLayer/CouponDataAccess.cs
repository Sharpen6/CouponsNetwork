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
        public static bool CreateCoupon(string name, string desc, double orgprice, double discount, Business b, string datee, int maxNum, List<string> interestt)
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
                foreach (string i in interestt)
                {
                    Interest t = FindInterest(b, i);
                    be.Entry(t).State = System.Data.Entity.EntityState.Unchanged;
                    cop.Interests.Add(t);
                }
                cop.ExperationDate = datee;
                cop.MaxNum = maxNum;
                cop.AvarageRanking = 0;
                cop.Business_BusinessID = b.BusinessID;

                cop.Business = be.Businesses.Find(b.BusinessID);
                //  cop.InterestId = interestt.Id;
                be.Coupons.Add(cop);
                be.SaveChanges();

                return true;
            }
        }
        public static Interest FindInterest(Business Category, string desription)
        {
            using (basicEntities be = new basicEntities())
            {
                var bus = from b in be.Interests
                          where b.Description == desription & b.BusinessCategory.Id == Category.BusinessCategoriesId
                          select b;
                Interest Interests = bus.First();


                return Interests;

            }
        }
     
        public static DataTable GetCouponsByCity(string city)
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

            using (basicEntities be = new basicEntities())
            {
                var bus = from b in be.Coupons
                          where b.Business.City.Name == city & b.Business.Block==false
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

        public static DataTable GetCouponsByBusniess(string Busniesss)
        {
            IQueryable<int> bus;
            using (basicEntities be = new basicEntities())
            {
                int i = Int32.Parse(Busniesss);
                bus = from b in be.Coupons
                      where b.Business.BusinessID == i
                      select b.Id;


                return GetDataTable(bus.ToList());
            }
        }

        public static DataTable GetCouponsByInterest(List<ListItem> selectedInterests)
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
                        if (interests.Contains(interest.Description) &item.Business.Block==false)
                        {
                            bus.Add(item.Id);
                            break;
                        }
                    }
                }
            }
            return GetDataTable(bus);
        }


        public static DataTable GetDataTable(List<int> items)
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

        public static bool RemoveCoupon(string CoponId)
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
            catch (Exception e)
            {
                return false;
            }
        }



        public static DataTable GetCouponsByGps(double coordinateX, double coordinateY)
        {
            throw new NotImplementedException();
        }

        public static DataTable GetCouponsByCityAndInterest(string city, List<ListItem> selectedInterests)
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
                        if (interests.Contains(interest.Description) & item.Business.City.Name == city &item.Business.Block==false)
                        {
                            bus.Add(item.Id);
                            break;
                        }
                    }
                }
            }
            return GetDataTable(bus);
        }

        public static bool EditCoupon(int copId, string p1, double p2, double p3, string p4, string p5, int mdp, List<ListItem> selected)
        {
            try
            {
                using (basicEntities be = new basicEntities())

                    if (be.Coupons.Find(copId) != null)
                    {
                        Coupon cop = be.Coupons.Find(copId);
                        cop.Name = p1;
                        cop.OriginalPrice = p2;
                        cop.DiscountPrice = p3;
                        cop.Description = p4;
                        cop.ExperationDate = p5;
                        cop.MaxNum = mdp;

                        ICollection<Interest> i = cop.Interests;
                        foreach (Interest item in i)
                        {                        
                            item.Coupons.Remove(cop); 
                        }
                        be.SaveChanges();
                    }

                using (basicEntities be = new basicEntities())

                    if (be.Coupons.Find(copId) != null)
                    {
                        foreach (ListItem z in selected)
                        {
                            Coupon cop = be.Coupons.Find(copId);
                            Interest t = FindInterest(cop.Business, z.Value);
                            be.Entry(t).State = System.Data.Entity.EntityState.Unchanged;
                            cop.Interests.Add(t);
                        }
                        be.SaveChanges();
                        return true;
                    }

                    else
                        return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static string FindCoupon(string p)
        {
            using (basicEntities be = new basicEntities())
            {
                int id = Int32.Parse(p);
                if (be.Coupons.Find(id) != null)
                {
                    Coupon cop = be.Coupons.Find(id);
                    return cop.ExperationDate;
                }
            }
            return null;
        }

        public static ICollection<Interest> findCopInterest(string p)
        {
          using (basicEntities be = new basicEntities())
            {
                int id = Int32.Parse(p);
                if (be.Coupons.Find(id) != null)
                {
                    Coupon cop = be.Coupons.Find(id);
                    return cop.Interests;
                }
            }
            return null;
        }
        }
    }
