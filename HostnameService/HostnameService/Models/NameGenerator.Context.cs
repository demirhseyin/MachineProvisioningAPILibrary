﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HostnameService.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NameGeneratorEntities : DbContext
    {
        public NameGeneratorEntities()
            : base("name=NameGeneratorEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Name> Names { get; set; }
        public virtual DbSet<NightWatch> NightWatches { get; set; }
        public virtual DbSet<Platformm> Platformms { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<QueryLog> QueryLogs { get; set; }
        public virtual DbSet<Rolee> Rolees { get; set; }
        public virtual DbSet<SQLDeployment> SQLDeployments { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<SystemAdmin> SystemAdmins { get; set; }
        public virtual DbSet<Typee> Typees { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}