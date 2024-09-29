using Microsoft.EntityFrameworkCore;
using ModularMonolithicArch.ImageGame.Domain.Entities;

namespace ModularMonolithicArch.ImageGame.Infrastructure.Context;

public class ImageGameContext(DbContextOptions<ImageGameContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Room> Rooms { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema(Schema.ImageGame);
    }
}
