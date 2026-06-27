namespace GymApp.DAL.Context.Configurations;

internal abstract class GymUserConfiguration<T> : IEntityTypeConfiguration<T> where T : GymUser
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(X => X.Name)
               .HasColumnType("varchar")
               .HasMaxLength(50);
        
        builder.Property(X => X.Email)
               .HasColumnType("varchar")
               .HasMaxLength(100);
        
        builder.OwnsOne(x => x.Address, address =>
        {
            address.Property(a => a.Street)
                   .HasColumnType("varchar")
                   .HasMaxLength(100);
            
            address.Property(a => a.City)
                   .HasColumnType("varchar")
                   .HasMaxLength(50);
        });

        builder.Property(X => X.Phone)
               .HasColumnType("char")
               .HasMaxLength(11);
        
        // Check constraint for Email Address and Phone
        builder.ToTable(x =>
        {
            x.HasCheckConstraint("EmailCheck", "Email LIKE '%@%.%'");
            x.HasCheckConstraint("PhoneCheck", "Phone LIKE '[0-9]%' AND LEN(Phone) = 11");
        });
    }
}