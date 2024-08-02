using GameHub.Domain.Entities;
using EIG = GameHub.Domain.Entities.ImageGame;
using EWG = GameHub.Domain.Entities.WordGame;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameHub.Infra.Context;

public class GameContext(DbContextOptions<GameContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    // WordGame Tables
    public DbSet<EWG.Category> WordGameCategories { get; set; }
    public DbSet<EWG.Level> WordGameLevels { get; set; }

    // ImageGame Tables
    public DbSet<EIG.Category> ImageGameCategories { get; set; }
    public DbSet<EIG.Image> ImageGameImages { get; set; }
    public DbSet<EIG.Room> ImageGameRooms { get; set; }
}
