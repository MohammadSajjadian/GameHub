using GameHub.Domain.Entities.ImageGame;

namespace GameHub.Domain.Repository.ImageGame;

public interface IImageService
{
    void MarkAsVisible(Image image);
    void MarkAsInVisible(Image image);
}
