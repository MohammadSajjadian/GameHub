using ModularMonolithicArch.ImageGame.Domain.Entities;

namespace ModularMonolithicArch.ImageGame.Domain.Repository;

public interface IImageService
{
    void MarkAsVisible(Image image);
    void MarkAsInVisible(Image image);
}
