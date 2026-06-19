using Microsoft.EntityFrameworkCore;
using GymApp.DAL.Models;
namespace GymApp.DAL.Context;

public class GymDbContext : DbContext
{
    public DbSet<Plan> Plans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
                        "Server=localhost,1433;Database=GymAppDb;User Id=sa;Password=saLma@287;TrustServerCertificate=True;"
        );    
    }
}