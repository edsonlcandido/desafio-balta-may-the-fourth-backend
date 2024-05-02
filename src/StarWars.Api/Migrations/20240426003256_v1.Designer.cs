﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StarWars.Infra.Data;

#nullable disable

namespace StarWars.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240426003256_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Film_Characters", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FilmId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CharacterId", "FilmId");

                    b.HasIndex("FilmId");

                    b.ToTable("Film_Characters");
                });

            modelBuilder.Entity("Film_Planet", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlanetId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FilmId", "PlanetId");

                    b.HasIndex("PlanetId");

                    b.ToTable("Film_Planet");
                });

            modelBuilder.Entity("Film_Spaceship", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpaceshipId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FilmId", "SpaceshipId");

                    b.HasIndex("SpaceshipId");

                    b.ToTable("Film_Spaceship");
                });

            modelBuilder.Entity("Film_Vehicle", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VehicleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FilmId", "VehicleId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Film_Vehicle");
                });

            modelBuilder.Entity("StarWars.Core.Context.StarWars.Entities.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BirthYear")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("BirthYear");

                    b.Property<string>("EyeColor")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("EyeColor");

                    b.Property<int>("FK_Character_Planet")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Gender");

                    b.Property<string>("HairColor")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("HairColor");

                    b.Property<string>("Height")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Height");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Name");

                    b.Property<int>("PlanetId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SkinColor")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("SkinColor");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Weight");

                    b.HasKey("Id");

                    b.HasIndex("FK_Character_Planet");

                    b.ToTable("Character", (string)null);
                });

            modelBuilder.Entity("StarWars.Core.Context.StarWars.Entities.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Director");

                    b.Property<string>("Episode")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Episode");

                    b.Property<string>("OpeningCrawl")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("OpeningCrawl");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Producer");

                    b.Property<string>("ReleaseDate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("ReleaseDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.ToTable("Film", (string)null);
                });

            modelBuilder.Entity("StarWars.Core.Context.StarWars.Entities.Planet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Climate")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Climate");

                    b.Property<string>("Diameter")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Diameter");

                    b.Property<string>("Gravity")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Gravity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Name");

                    b.Property<string>("OrbitalPeriod")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("OrbitalPeriod");

                    b.Property<string>("Population")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Population");

                    b.Property<string>("RotationPeriod")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("RotationPeriod");

                    b.Property<string>("SurfaceWater")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("SurfaceWater");

                    b.Property<string>("Terrain")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Terrain");

                    b.HasKey("Id");

                    b.ToTable("Planet", (string)null);
                });

            modelBuilder.Entity("StarWars.Core.Context.StarWars.Entities.Spaceship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CargoCapacity")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("CargoCapacity");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Class");

                    b.Property<string>("Consumables")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Consumables");

                    b.Property<string>("CostInCredits")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("CostInCredits");

                    b.Property<string>("Crew")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Crew");

                    b.Property<string>("HyperdriveRating")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("HyperdriveRating");

                    b.Property<string>("Length")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MGLT")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("MGLT");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Manufacturer");

                    b.Property<string>("MaxSpeed")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("MaxSpeed");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Model");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Name");

                    b.Property<string>("Passengers")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Passengers");

                    b.HasKey("Id");

                    b.ToTable("Spaceship", (string)null);
                });

            modelBuilder.Entity("StarWars.Core.Context.StarWars.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CargoCapacity")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("CargoCapacity");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Class");

                    b.Property<string>("Consumables")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Consumables");

                    b.Property<string>("CostInCredits")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("CostInCredits");

                    b.Property<string>("Crew")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Crew");

                    b.Property<string>("Length")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Manufacturer");

                    b.Property<string>("MaxSpeed")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("MaxSpeed");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Model");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Name");

                    b.Property<string>("Passengers")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Passengers");

                    b.HasKey("Id");

                    b.ToTable("Vehicle", (string)null);
                });

            modelBuilder.Entity("Film_Characters", b =>
                {
                    b.HasOne("StarWars.Core.Context.StarWars.Entities.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarWars.Core.Context.StarWars.Entities.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Film_Planet", b =>
                {
                    b.HasOne("StarWars.Core.Context.StarWars.Entities.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarWars.Core.Context.StarWars.Entities.Planet", null)
                        .WithMany()
                        .HasForeignKey("PlanetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Film_Spaceship", b =>
                {
                    b.HasOne("StarWars.Core.Context.StarWars.Entities.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarWars.Core.Context.StarWars.Entities.Spaceship", null)
                        .WithMany()
                        .HasForeignKey("SpaceshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Film_Vehicle", b =>
                {
                    b.HasOne("StarWars.Core.Context.StarWars.Entities.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarWars.Core.Context.StarWars.Entities.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StarWars.Core.Context.StarWars.Entities.Character", b =>
                {
                    b.HasOne("StarWars.Core.Context.StarWars.Entities.Planet", "Planet")
                        .WithMany("Characters")
                        .HasForeignKey("FK_Character_Planet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Planet");
                });

            modelBuilder.Entity("StarWars.Core.Context.StarWars.Entities.Planet", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
