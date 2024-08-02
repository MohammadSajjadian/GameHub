using System.ComponentModel.DataAnnotations.Schema;

namespace GameHub.Domain.Entities.ImageGame;

public class Image
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public int CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = default!;
}
