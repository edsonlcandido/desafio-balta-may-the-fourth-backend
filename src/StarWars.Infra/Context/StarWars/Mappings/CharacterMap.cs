using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.Core.Context.StarWars.Entities;

namespace StarWars.Infra.Context.StarWars.Mappings;

public class CharacterMap : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.ToTable("Character");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Height)
            .IsRequired()
            .HasColumnName("Height")
            .HasColumnType("VARCHAR")
            .HasMaxLength(5);
        
        builder.Property(x => x.Weight)
            .IsRequired()
            .HasColumnName("Weight")
            .HasColumnType("VARCHAR")
            .HasMaxLength(5);

        builder.Property(x => x.HairColor)
            .IsRequired()
            .HasColumnName("HairColor")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20);

        builder.Property(x => x.SkinColor)
            .IsRequired()
            .HasColumnName("SkinColor")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20);

        builder.Property(x => x.EyeColor)
            .IsRequired()
            .HasColumnName("EyeColor")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20);

        builder.Property(x => x.BirthYear)
            .IsRequired()
            .HasColumnName("BirthYear")
            .HasColumnType("VARCHAR")
            .HasMaxLength(10);

        builder.Property(x => x.Gender)
            .IsRequired()
            .HasColumnName("Gender")
            .HasColumnType("VARCHAR")
            .HasMaxLength(15);

        builder.HasOne(x => x.Planet)
            .WithMany(y => y.Characters)
            .HasForeignKey("FK_Character_Planet")
            .OnDelete(DeleteBehavior.Cascade);
    }
}