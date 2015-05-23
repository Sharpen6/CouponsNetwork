using CouponsOnline.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace CouponsOnline.BusinessLayer.Controllers
{
    public class CouponController
    {
        internal static DataTable GetCouponsByCity(string city)
        {
            DataTable table = ToDataTable<Coupon>(CouponDataAccess.GetCouponsByCity(city));
            return table;
        }
        private static DataTable ToDataTable<T>(T entity) where T : class
        {
            var properties = typeof(T).GetProperties();
            var table = new DataTable();

            foreach (var property in properties)
            {
                table.Columns.Add(property.Name, property.PropertyType);
            }

            table.Rows.Add(properties.Select(p => p.GetValue(entity, null)).ToArray());
            return table;
        }
    }
}