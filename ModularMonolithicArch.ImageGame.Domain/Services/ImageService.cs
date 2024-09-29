using ModularMonolithicArch.ImageGame.Domain.Entities;
using ModularMonolithicArch.ImageGame.Domain.Repository;

namespace ModularMonolithicArch.ImageGame.Domain.Services;

public class ImageService : IImageService
{
    public void MarkAsInVisible(Image image)
        => image.IsVisible = false;

    public void MarkAsVisible(Image image)
        => image.IsVisible = true;
}
