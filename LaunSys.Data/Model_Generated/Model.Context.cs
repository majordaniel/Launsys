﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LaunSys.Data.Model_Generated
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LaunSysDBEntities : DbContext
    {
        public LaunSysDBEntities()
            : base("name=LaunSysDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_Branch> tb_Branch { get; set; }
        public virtual DbSet<tb_City> tb_City { get; set; }
        public virtual DbSet<tb_Country> tb_Country { get; set; }
        public virtual DbSet<tb_Customers> tb_Customers { get; set; }
        public virtual DbSet<tb_Department> tb_Department { get; set; }
        public virtual DbSet<tb_Division> tb_Division { get; set; }
        public virtual DbSet<tb_Employees> tb_Employees { get; set; }
        public virtual DbSet<tb_Expenses> tb_Expenses { get; set; }
        public virtual DbSet<tb_FabricDescription> tb_FabricDescription { get; set; }
        public virtual DbSet<tb_Gender> tb_Gender { get; set; }
        public virtual DbSet<tb_Income> tb_Income { get; set; }
        public virtual DbSet<tb_IncomingFabric> tb_IncomingFabric { get; set; }
        public virtual DbSet<tb_LGA> tb_LGA { get; set; }
        public virtual DbSet<tb_Receipt> tb_Receipt { get; set; }
        public virtual DbSet<tb_Region> tb_Region { get; set; }
        public virtual DbSet<tb_Role> tb_Role { get; set; }
        public virtual DbSet<tb_State> tb_State { get; set; }
        public virtual DbSet<tb_Status> tb_Status { get; set; }
        public virtual DbSet<tb_Titles> tb_Titles { get; set; }
        public virtual DbSet<tb_Users> tb_Users { get; set; }
    }
}