using ModularMonolithicArch.ImageGame.Domain.Entities;
using ModularMonolithicArch.ImageGame.Domain.Services;

namespace ModularMonolithicArch.ImageGame.Domain.Repository;

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
