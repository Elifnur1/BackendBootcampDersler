using System;
using Microsoft.EntityFrameworkCore;

namespace Proje13_EFCoreIntro;

public class ApplicationDbContext : DbContext
{
      public DbSet<Category> Categories { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1441;Database=EfCoreIntroDb;User=sa;Password=YourStrong@Pasw0rd;TrustServerCertificate=true");
        base.OnConfiguring(optionsBuilder);
    }
}
