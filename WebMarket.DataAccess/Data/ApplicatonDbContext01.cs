using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Webmarket.Modelss;
using WebMarket.Modelss;

namespace WebMarket.DataAccess.Data
{
    public class ApplicatonDbContext01 : IdentityDbContext
    {
        public ApplicatonDbContext01(DbContextOptions<ApplicatonDbContext01> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet <Company> Companies { get; set; }

    }
}
