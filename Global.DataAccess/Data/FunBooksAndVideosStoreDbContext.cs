using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.DataAccess.Data.Table;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Global.DataAccess.Data
{
   public class FunBooksAndVideosStoreDbContext:IdentityDbContext<ApplicationUser>
    {
        public FunBooksAndVideosStoreDbContext(DbContextOptions<FunBooksAndVideosStoreDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }

        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }

        public DbSet<Subscription> Subscription { get; set; }

        public DbSet<Addresses> Addresses { get; set; }


    }


}
