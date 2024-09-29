using ModularMonolithicArch.ImageGame.Domain.Entities;
using ModularMonolithicArch.ImageGame.Domain.Repository;

namespace ModularMonolithicArch.ImageGame.Domain.Services;

public class ImageGameService(IImageService imageService) : IImageGameService
{
    private List<Image> _selectedItems = [];
    private const int _maxSelectedItem = 2;
    private int _creatorScore;
    private int _guestScore;
    private bool _creatorTurn = true;

    public event EventHandler<EndGameEventArgs> OnEndGame = default!;

    public bool CreatorTurn => _creatorTurn;
    public int CreatorScore => _creatorScore;
    public int GuestScore => _guestScore;
    public List<Image> Images { get; set; } = [];

    public void Initialize(List<Image> images, int seed)
    {
        Images = images
            .DuplicateImages()
            .RandomizeImages(seed)
            .ToList();
    }

    public async Task AddSelectedItem(Image image)
    {
        if (_selectedItems.Count < _maxSelectedItem)
        {
            _selectedItems.Add(image);
        }

        if (_selectedItems.Count is _maxSelectedItem)
        {
            await CheckAnswer();
        }
    }

    private async Task CheckAnswer()
    {
        if (_selectedItems[0].Name == _selectedItems[1].Name)
        {
            ManageScores();
        }
        else
        {
            await Task.Delay(500);
            Images.Where(i => i.Name == _selectedItems[0].Name || i.Name == _selectedItems[1].Name)
                  .ToList()
                  .ForEach(imageService.MarkAsInVisible);

            _creatorTurn = !_creatorTurn;
        }

        if (Images.All(i => i.IsVisible == true))
        {
            OnEndGame.Invoke(this, new EndGameEventArgs { Message = "Game ended🤩" });
        }
        _selectedItems.Clear();
    }

    public void ResetStates()
    {
        _creatorTurn = true;
        _creatorScore = 0;
        _guestScore = 0;
    }

    private int ManageScores()
        => _creatorTurn ? _creatorScore++ : _guestScore++;
}

public class EndGameEventArgs : EventArgs
{
    public string Message { get; init; } = string.Empty;
}

internal static class ImageGameServiceExtensions
{
    private static int _id = 1;
    public static IEnumerable<Image> DuplicateImages(this IEnumerable<Image> source)
        => source.Concat(source).Select(image => new Image() { Id = _id++, Name = image.Name });

    public static IEnumerable<TSource> RandomizeImages<TSource>(this IEnumerable<TSource> source, int seed)
    {
        var random = new Random(seed);
        return source.OrderBy(_ => random.Next());
    }
}
