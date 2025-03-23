using Microsoft.EntityFrameworkCore;
using Movie.Persistance.Configurations;
using Movie.Persistance.Entities;

namespace Movie.Persistance;

public class MovieDbContext(DbContextOptions options):DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<MovieEntity> Movies { get; set; }
    public DbSet<RatingEntity> Ratings { get; set; }
    public DbSet<ReviewEntity> Reviews { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MovieConfigurations());
        modelBuilder.ApplyConfiguration(new RatingConfigurations());
        modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfigurations());
    }
}