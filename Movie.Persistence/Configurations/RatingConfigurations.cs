using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.Persistance.Entities;

namespace Movie.Persistance.Configurations;

public class RatingConfigurations : IEntityTypeConfiguration<RatingEntity>
{
    public void Configure(EntityTypeBuilder<RatingEntity> builder)
    {
        builder.ToTable("Ratings");

        builder.Property(r => r.Score)
            .IsRequired()
            .HasColumnType("int")
            .HasDefaultValue(1)
            .HasComment("Оценка от 1 до 10");

        builder.HasOne(r => r.Movie)
            .WithMany(m => m.Ratings)
            .HasForeignKey(r => r.MovieId)
            .OnDelete(DeleteBehavior.Cascade); 
        
        builder.HasOne(r => r.User)
            .WithMany(u => u.Ratings)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}