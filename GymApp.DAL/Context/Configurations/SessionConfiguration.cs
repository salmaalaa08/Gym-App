namespace GymApp.DAL.Context.Configurations;

internal class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        // Check Constraints
        builder.ToTable(x =>
        {
            x.HasCheckConstraint("SessionDateCheck", "StartDate < EndDate");
            x.HasCheckConstraint("SessionCapacityCheck", "Capacity BETWEEN 1 AND 25");
        });
    }
}