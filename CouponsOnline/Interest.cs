//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CouponsOnline
{
    using System;
    using System.Collections.Generic;
    
    public partial class Interest
    {
        public Interest()
        {
            this.Coupons = new HashSet<Coupon>();
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<Coupon> Coupons { get; set; }
        public virtual BusinessCategories BusinessCategory { get; set; }
    }
}
