namespace GymApp.DAL.Context;

public class GymDbContext : DbContext
{
    // Constructor to pass options to the base DbContext class
    // options will be created in the Program.cs file and passed to the DbContext
    public GymDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Plan> Plans { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<HealthRecord> HealthRecords { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Membership> Memberships { get; set; }

    // onConfig => send configuration to the Base dbContext

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GymDbContext).Assembly);
    }
}