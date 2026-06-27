namespace GymApp.DAL.Context.Configurations;

internal class TrainerConfiguration : GymUserConfiguration<Trainer>, IEntityTypeConfiguration<Trainer>
{
    public new void Configure(EntityTypeBuilder<Trainer> builder)
    {
        builder.Property(x => x.Speciality)
               .HasConversion<string>();

        base.Configure(builder);
    }
}