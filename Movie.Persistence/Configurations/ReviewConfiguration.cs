using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.Persistance.Entities;

namespace Movie.Persistance.Configurations;

public class ReviewConfiguration: IEntityTypeConfiguration<ReviewEntity>
{
    public void Configure(EntityTypeBuilder<ReviewEntity> builder)
    {
       builder.HasKey(r => r.Id);
       
       builder.ToTable("Reviews");
       
       builder.Property(r => r.Title)
           .IsRequired()
           .HasMaxLength(150);
       
       builder.Property(r => r.Content)
           .IsRequired();
       
       builder.Property(r => r.Date)
           .IsRequired();

       builder.HasOne(r => r.User)
           .WithMany(u => u.Reviews)
           .HasForeignKey(r => r.UserId)
           .OnDelete(DeleteBehavior.Restrict);
       
       builder.HasOne(r => r.Movie) 
           .WithMany(m => m.Reviews)
           .HasForeignKey(r => r.MovieId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}