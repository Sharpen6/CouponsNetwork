using CouponsOnline.BusinessLayer;
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
        public static bool CreateCoupon(string name, string desc,
            string orgprice, string discount, Business b,
            string datee, string maxNum, List<string> interests)
        {
            using (basicEntities be = new basicEntities())
            {
                Coupon cop = new Coupon();
                cop.Name = name;
                cop.Description = desc;
                cop.OriginalPrice = double.Parse(orgprice);
                cop.DiscountPrice = double.Parse(discount);
                cop.Business = b;
                be.Entry(b).State = System.Data.Entity.EntityState.Unchanged;
                //  cop.Interest = interestt;
                foreach (string i in interests)
                {
                    //Interest t = FindInterest(b, i);
                    int interestId = int.Parse(i);
                    Interest t = be.Interests.Find(interestId);
                    be.Entry(t).State = System.Data.Entity.EntityState.Unchanged;
                    cop.Interests.Add(t);
                }
                cop.ExperationDate = datee;
                cop.MaxNum = int.Parse(maxNum);
                cop.AvarageRanking = 0;
                cop.Business_BusinessID = b.BusinessID;

                cop.Business = be.Businesses.Find(b.BusinessID);
                //  cop.InterestId = interestt.Id;
                be.Coupons.Add(cop);
                be.SaveChanges();

                return true;
            }
        }

        public static DataTable GetAllCoupons(List<int> items)
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
                    dr[5] = item.Business.City.Name;
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
        public static bool EditCoupon(int copId, string name, double org, double disc, string desc, string exp, int mdp, List<ListItem> selected)
        {
            try
            {
                using (basicEntities be = new basicEntities())

                    if (be.Coupons.Find(copId) != null)
                    {
                        Coupon cop = be.Coupons.Find(copId);
                        cop.Name = name;
                        cop.OriginalPrice = org;
                        cop.DiscountPrice = disc;
                        cop.Description = desc;
                        cop.ExperationDate = exp;
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
                            Interest t = be.Interests.Find(int.Parse(z.Value));
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
        
        
        public static Coupon GetCoupon(string id)
        {
            using (basicEntities be = new basicEntities())
            {
                Coupon cop = be.Coupons.Find(int.Parse(id));
                be.Entry(cop).Collection(p => p.Interests).Load();
                return cop;
            }
        }
        public static DataTable GetCouponsByGps(double coordinateX, double coordinateY)
        {
            DataTable table = new DataTable();
            table.Columns.Add("How Far? (Km)");
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Original Price", typeof(double));
            table.Columns.Add("New Price", typeof(double));
            table.Columns.Add("Location", typeof(string));
            table.Columns.Add("Rating", typeof(double));

            using (basicEntities be = new basicEntities())
            {
                foreach (var item in be.Coupons)
                {
                    if (item.Business.Sensor_Id != null)
                    {
                        Location loc = be.Locations.Find(item.Business.Sensor_Id);
                        string lon = loc.Longitude;
                        string lat = loc.Latitude;
                        double lon2 = double.Parse(lon);
                        double lat2 = double.Parse(lat);
                        DataRow dr = table.NewRow();
                        dr[0] = GeoLocator.DistanceTo(coordinateX, coordinateY, lon2, lat2).ToString("0.## km");
                        dr[1] = item.Name;
                        dr[2] = item.Description;
                        dr[3] = item.OriginalPrice;
                        dr[4] = item.DiscountPrice;
                        dr[5] = item.Business.City.Name;
                        dr[6] = item.AvarageRanking;
                       
                        table.Rows.Add(dr);
                    }
                }
            }
            return table;
        }
        public static DataTable GetCouponsByCityAndInterest(string city, List<ListItem> selectedInterests)
        {
            int cityNum =int.Parse(city);
            List<string> interests = new List<string>();
            foreach (var item in selectedInterests)
            {
                interests.Add(item.Value);
            }
            List<int> bus = new List<int>();
            using (basicEntities be = new basicEntities())
            {
                foreach (var item in be.Coupons)
                {
                    if (item.Business.City.Id != cityNum) continue;
                    foreach (var interest in item.Interests)
                    {
                        if (interests.Contains(interest.Id.ToString()))
                        {
                            bus.Add(item.Id);
                            break;
                        }
                    }
                }
            }
            return GetAllCoupons(bus);
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
                          where b.Business.City.Id.ToString() == city && b.Business.Blocked == false
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
        public static DataTable GetCouponsByBusniess(int Business)
        {
            IQueryable<int> bus;
            using (basicEntities be = new basicEntities())
            {
                bus = from b in be.Coupons
                      where b.Business.BusinessID == Business
                      select b.Id;
                return GetAllCoupons(bus.ToList());
            }
        }
        public static DataTable GetCouponsByInterest(List<string> interests)
        {
            List<int> bus = new List<int>();
            using (basicEntities be = new basicEntities())
            {
                foreach (var item in be.Coupons)
                {
                    foreach (var interest in item.Interests)
                    {
                        if (interests.Contains(interest.Id.ToString()) & item.Business.Blocked == false)
                        {
                            bus.Add(item.Id);
                            break;
                        }
                    }
                }
            }
            return GetAllCoupons(bus);
        }

    }
}

