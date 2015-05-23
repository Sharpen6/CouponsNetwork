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
                cop.Business_BusinessID = b.BusinessCategoriesId;

                cop.Business = be.Businesses.Find(b.BusinessCategoriesId);
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

            using (basicEntities be = new basicEntities())
            {
                foreach (var item in be.Coupons)
                {
                    DataRow dr = table.NewRow();
                    dr[0] = item.Name;
                    dr[1] = item.Description;
                    dr[2] = item.OriginalPrice;
                    dr[3] = item.DiscountPrice;
                    dr[4] = item.Business.Name;
                    dr[5] = item.Business.Address+", "+item.Business.City;
                    dr[6] = item.AvarageRanking; 
                    dr[7] = item.MaxNum;
                    table.Rows.Add(dr);
                }
            }
            return table;
        }
    }
}