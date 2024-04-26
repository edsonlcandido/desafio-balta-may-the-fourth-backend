using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.Core.Context.StarWars.Entities;

namespace StarWars.Infra.Context.StarWars.Mappings;

public class FilmMap : IEntityTypeConfiguration<Film>
{
    public void Configure(EntityTypeBuilder<Film> builder)
    {
        builder.ToTable("Film");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnName("Title")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Episode)
            .IsRequired()
            .HasColumnName("Episode")
            .HasColumnType("VARCHAR")
            .HasMaxLength(2);

        builder.Property(x => x.OpeningCrawl)
            .IsRequired()
            .HasColumnName("OpeningCrawl")
            .HasColumnType("TEXT");

        builder.Property(x => x.Director)
            .IsRequired()
            .HasColumnName("Director")
            .HasColumnType("VARCHAR")
            .HasMaxLength(40);

        builder.Property(x => x.Producer)
            .IsRequired()
            .HasColumnName("Producer")
            .HasColumnType("VARCHAR")
            .HasMaxLength(40);

        builder.Property(x => x.ReleaseDate)
            .IsRequired()
            .HasColumnName("ReleaseDate")
            .HasColumnType("VARCHAR")
            .HasMaxLength(10);

        builder.HasMany(x => x.Characters)
            .WithMany(y => y.Films)
            .UsingEntity<Dictionary<string, object>>(
                "Film_Characters",
                film => film.HasOne<Character>()
                    .WithMany()
                    .HasForeignKey("CharacterId")
                    .OnDelete(DeleteBehavior.Cascade),
                character => character.HasOne<Film>()
                    .WithMany()
                    .HasForeignKey("FilmId")
                    .OnDelete(DeleteBehavior.Cascade)
            );

        builder.HasMany(x => x.Planets)
            .WithMany(x => x.Films)
            .UsingEntity<Dictionary<string, object>>(
                "Film_Planet",
                film => film.HasOne<Planet>()
                    .WithMany()
                    .HasForeignKey("PlanetId")
                    .OnDelete(DeleteBehavior.Cascade),
                planet => planet.HasOne<Film>()
                    .WithMany()
                    .HasForeignKey("FilmId")
                    .OnDelete(DeleteBehavior.Cascade)
            );

        builder.HasMany(x => x.Vehicles)
            .WithMany(y => y.Films)
            .UsingEntity<Dictionary<string, object>>(
                "Film_Vehicle",
                film => film.HasOne<Vehicle>()
                    .WithMany()
                    .HasForeignKey("VehicleId")
                    .OnDelete(DeleteBehavior.Cascade),
                vehicle => vehicle.HasOne<Film>()
                    .WithMany()
                    .HasForeignKey("FilmId")
                    .OnDelete(DeleteBehavior.Cascade)
            );

        builder.HasMany(x => x.Spaceships)
            .WithMany(y => y.Films)
            .UsingEntity<Dictionary<string, object>>(
                "Film_Spaceship",
                film => film.HasOne<Spaceship>()
                    .WithMany()
                    .HasForeignKey("SpaceshipId")
                    .OnDelete(DeleteBehavior.Cascade),
                spaceship => spaceship.HasOne<Film>()
                    .WithMany()
                    .HasForeignKey("FilmId")
                    .OnDelete(DeleteBehavior.Cascade)
            );
    }
}