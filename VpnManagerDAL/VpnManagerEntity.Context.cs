﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VpnManagerDAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VpnManagerEntities : DbContext
    {
        public VpnManagerEntities()
            : base("name=VpnManagerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Machine> Machine { get; set; }
        public DbSet<Plant> Plant { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<VpnType> VpnType { get; set; }
        public DbSet<ConnectionType> ConnectionType { get; set; }
        public DbSet<ExtensionObjects> ExtensionObjects { get; set; }
        public DbSet<LogConenction> LogConenction { get; set; }
    }
}
