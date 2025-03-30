using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.Persistance.Entities;

namespace Movie.Persistance.Configurations;

public class MovieConfigurations : IEntityTypeConfiguration<MovieEntity>
{
    public void Configure(EntityTypeBuilder<MovieEntity> builder)
    {
        builder.HasKey(m => m.Id);
        
        builder.ToTable("Movies");
        
        builder.Property(m => m.Year)
            .IsRequired();

        builder.Property(m => m.Description)
            .IsRequired()
            .HasMaxLength(500);
        
        builder.Property(m => m.Title)
            .IsRequired()
            .HasMaxLength(150);
        
        builder.Property(m => m.PosterUrl)
            .IsRequired(false);
        
        builder.Property(m => m.Genre)
            .HasConversion<string>()
            .HasMaxLength(50);
        
        builder.HasMany(m => m.Ratings)
            .WithOne(r => r.Movie)
            .HasForeignKey(r => r.MovieId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(m => m.Reviews)
            .WithOne(r => r.Movie)
            .HasForeignKey(r => r.MovieId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}