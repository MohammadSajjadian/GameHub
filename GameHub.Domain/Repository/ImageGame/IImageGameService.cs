using GameHub.Domain.Entities.ImageGame;
using GameHub.Domain.Services.ImageGame;

namespace GameHub.Domain.Repository.ImageGame;

public interface IImageGameService
{
    bool CreatorTurn { get; }
    int CreatorScore { get; }
    int GuestScore { get; }
    List<Image> Images { get; set; }
    event EventHandler<EndGameEventArgs> OnEndGame;

    void Initialize(List<Image> images, int seed);
    Task AddSelectedItem(Image image);
    void ResetStates();
}
