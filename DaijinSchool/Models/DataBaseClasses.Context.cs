﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DaijinSchool.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DaidjinSchoolEntities : DbContext
    {
        public DaidjinSchoolEntities()
            : base("name=DaidjinSchoolEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Chats> Chats { get; set; }
        public virtual DbSet<DeletedCourses> DeletedCourses { get; set; }
        public virtual DbSet<FeedBack> FeedBack { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<PreOrder> PreOrder { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<Rate> Rate { get; set; }
        public virtual DbSet<Remainder> Remainder { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<ScheduleMaterial> ScheduleMaterial { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<UserDB> UserDB { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<ListOfCourses> ListOfCourses { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
    }
}