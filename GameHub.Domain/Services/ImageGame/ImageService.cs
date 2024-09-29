using GameHub.Domain.Entities.ImageGame;
using GameHub.Domain.Repository.ImageGame;

namespace GameHub.Domain.Services.ImageGame;

public class ImageService : IImageService
{
    public void MarkAsInVisible(Image image)
        => image.IsVisible = false;

    public void MarkAsVisible(Image image)
        => image.IsVisible = true;
}
