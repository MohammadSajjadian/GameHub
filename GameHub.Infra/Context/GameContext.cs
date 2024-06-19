using GameHub.Domain.Entities;
using GameHub.Domain.Entities.WordGame;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameHub.Infra.Context;

public class GameContext(DbContextOptions<GameContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<WordGameLevel> WordGameLevels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var categoryBuilder = modelBuilder.Entity<Category>();
        categoryBuilder.HasKey(c => c.Id);
        categoryBuilder.Property(c => c.Id).ValueGeneratedOnAdd();
        categoryBuilder.Property(c => c.Name).IsRequired();


        var wgBuilder = modelBuilder.Entity<WordGameLevel>();
        wgBuilder.HasKey(l => l.Id);
        wgBuilder.Property(l => l.Id).ValueGeneratedOnAdd();
        wgBuilder.Property(l => l.LevelNumber).IsRequired();
        wgBuilder.Property(l => l.Word).IsRequired();
        wgBuilder.Property(l => l.Hint).IsRequired();

        base.OnModelCreating(modelBuilder);
    }
}
