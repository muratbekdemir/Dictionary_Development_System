﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dictionary_Development_System_Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DDS_Context : DbContext
    {
        public DDS_Context()
            : base("name=DDS_Context")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Dictionary> Dictionary { get; set; }
        public virtual DbSet<Interest> Interest { get; set; }
        public virtual DbSet<TempWord> TempWord { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Votes> Votes { get; set; }
    }
}
