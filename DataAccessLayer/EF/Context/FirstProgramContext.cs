using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace DataAccessLayer.EF.Context
{
    public class FirstProgramContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-R04PVQ3\\SQLEXPRESS;database=FirstDb;trusted_connection=true;TrustServerCertificate=true;");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Authorize> Authorize { get; set; }
        public DbSet<Request> Requests { get; set; }

    }
}
