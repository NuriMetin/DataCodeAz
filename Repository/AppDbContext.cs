using DataAccess.Entites;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Repository
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<OurService> OurServices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PortfolioCategory> PortfolioCategories { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Contact> Contacts { get; set; }


        //------------------------------------------------------


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
