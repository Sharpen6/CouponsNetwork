﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class basicEntities : DbContext
    {
        public basicEntities()
            : base("name=basicEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<Sensor> Sensors { get; set; }
        public virtual DbSet<OrderedCoupon> OrderedCoupons { get; set; }
        public virtual DbSet<RecommendedCoupon> RecommendedCoupons { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Users_Admin> Users_Admin { get; set; }
        public virtual DbSet<Users_Customer> Users_Customer { get; set; }
        public virtual DbSet<Users_Owner> Users_Owner { get; set; }
        public virtual DbSet<UserInfo> UserInfoes { get; set; }
        public virtual DbSet<BusinessCategories> BusinessCategories { get; set; }
        public virtual DbSet<Interest> Interests { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
    }
}
