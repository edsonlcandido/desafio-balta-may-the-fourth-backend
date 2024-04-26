using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.Core.Context.StarWars.Entities;

namespace StarWars.Infra.Context.StarWars.Mappings;

public class SpaceshipMap : IEntityTypeConfiguration<Spaceship>
{
    public void Configure(EntityTypeBuilder<Spaceship> builder)
    {
        builder.ToTable("Vehicle");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50);
        
        builder.Property(x => x.Model)
            .IsRequired()
            .HasColumnName("Model")
            .HasColumnType("VARCHAR")
            .HasMaxLength(30);

        builder.Property(x => x.Manufacturer)
            .IsRequired()
            .HasColumnName("Manufacturer")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.CostInCredits)
            .IsRequired()
            .HasColumnName("CostInCredits")
            .HasColumnType("VARCHAR")
            .HasMaxLength(15);
        
        builder.Property(x => x.MaxSpeed)
            .IsRequired()
            .HasColumnName("MaxSpeed")
            .HasColumnType("VARCHAR")
            .HasMaxLength(10);

        builder.Property(x => x.Crew)
            .IsRequired()
            .HasColumnName("Crew")
            .HasColumnType("VARCHAR")
            .HasMaxLength(4);
        
        builder.Property(x => x.Passengers)
            .IsRequired()
            .HasColumnName("Passengers")
            .HasColumnType("VARCHAR")
            .HasMaxLength(4);

        builder.Property(x => x.CargoCapacity)
            .IsRequired()
            .HasColumnName("CargoCapacity")
            .HasColumnType("VARCHAR")
            .HasMaxLength(15);

        builder.Property(x => x.Consumables)
            .IsRequired()
            .HasColumnName("Consumables")
            .HasColumnType("VARCHAR")
            .HasMaxLength(15);

        builder.Property(x => x.Class)
            .IsRequired()
            .HasColumnName("Class")
            .HasColumnType("VARCHAR")
            .HasMaxLength(30);

        builder.Property(x => x.HyperdriveRating)
            .IsRequired()
            .HasColumnName("HyperdriveRating")
            .HasColumnType("VARCHAR")
            .HasMaxLength(4);

        builder.Property(x => x.MGLT)
            .IsRequired()
            .HasColumnName("MGLT")
            .HasColumnType("VARCHAR")
            .HasMaxLength(4);
    }
}