using Microsoft.EntityFrameworkCore;
using ModularMonolithicArch.WordGame.Domain.Entities;

namespace ModularMonolithicArch.WordGame.Infrastructure.Context;

public class WordGameContext(DbContextOptions<WordGameContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Level> Levels { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema(Schema.WordGame);
    }
}
