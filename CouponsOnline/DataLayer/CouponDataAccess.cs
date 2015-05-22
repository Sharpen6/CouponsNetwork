using System;
using System.Collections.Generic;
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
    }
}