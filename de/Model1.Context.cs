﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace de
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ТехносервисEntities : DbContext
    {
        public ТехносервисEntities()
            : base("name=ТехносервисEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Stage> Stage { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TypeMalfunctions> TypeMalfunctions { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
