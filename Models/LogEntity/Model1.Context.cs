﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CashAdvanceMvC.Models.LogEntity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CashAdvanceDbEntities : DbContext
    {
        public CashAdvanceDbEntities()
            : base("name=CashAdvanceDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__EFMigrationsHistory> C__EFMigrationsHistory { get; set; }
        public virtual DbSet<DbCashAdvance> DbCashAdvances { get; set; }
        public virtual DbSet<DbDepartment> DbDepartments { get; set; }
        public virtual DbSet<DbEmployee> DbEmployees { get; set; }
    }
}