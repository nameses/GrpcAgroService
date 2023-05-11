using GrpcAgroService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Xml;

namespace GrpcAgroService.Data
{
    public class ServerDbContext : DbContext
    {
        public DbSet<AgroFieldModel> AgroFields { get; set; }
        // other DbSet properties for other entities in your data model

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NAMESES;Database=AgroFieldDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgroFieldModel>()
                .HasKey(e => e.Name);
        }
    }
}