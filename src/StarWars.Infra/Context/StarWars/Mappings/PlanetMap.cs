using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.Core.Context.StarWars.Entities;

namespace StarWars.Infra.Context.StarWars.Mappings;

public class PlanetMap : IEntityTypeConfiguration<Planet>
{
    public void Configure(EntityTypeBuilder<Planet> builder)
    {
        builder.ToTable("Planet");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.RotationPeriod)
            .IsRequired()
            .HasColumnName("RotationPeriod")
            .HasColumnType("VARCHAR")
            .HasMaxLength(15);

        builder.Property(x => x.OrbitalPeriod)
            .IsRequired()
            .HasColumnName("OrbitalPeriod")
            .HasColumnType("VARCHAR")
            .HasMaxLength(15);

        builder.Property(x => x.Diameter)
            .IsRequired()
            .HasColumnName("Diameter")
            .HasColumnType("VARCHAR")
            .HasMaxLength(15);

        builder.Property(x => x.Climate)
            .IsRequired()
            .HasColumnName("Climate")
            .HasColumnType("VARCHAR")
            .HasMaxLength(30);

        builder.Property(x => x.Gravity)
            .IsRequired()
            .HasColumnName("Gravity")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20);

        builder.Property(x => x.Terrain)
            .IsRequired()
            .HasColumnName("Terrain")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.SurfaceWater)
            .IsRequired()
            .HasColumnName("SurfaceWater")
            .HasColumnType("VARCHAR")
            .HasMaxLength(4);

        builder.Property(x => x.Population)
            .IsRequired()
            .HasColumnName("Population")
            .HasColumnType("VARCHAR")
            .HasMaxLength(15);
    }
}