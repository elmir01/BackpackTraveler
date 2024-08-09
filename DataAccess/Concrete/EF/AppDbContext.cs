using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-K0V6ESA\SQLEXPRESS;Database=BackpackTravelerDb3;Trusted_Connection = true;TrustServerCertificate=true");

        }
        DbSet<AboutMe> AboutMes { get; set; }   
        DbSet<Faq> FaqPages { get; set; }   
        DbSet<Category> Categories { get; set; }
        DbSet<Travel> Travels { get; set; } 
       DbSet<TravelToCategory> TravelToCategories { get; set; }
    }
}
