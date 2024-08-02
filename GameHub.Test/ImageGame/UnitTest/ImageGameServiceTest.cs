using GameHub.Presentation.Client.Services.ImageGame;

namespace GameHub.Test.ImageGame.UnitTest;

public class ImageGameServiceTest
{
    [Fact]
    public void Initialize_WhenInitializeImages_ShouldDuplicateImages()
    {
        // Arrange
        ImageGameService service = new()
        {
            Images = [new Image { Value = "image1" }, new Image { Value = "image2" }]
        };

        // Act
        service.Initialize(service.Images, 3);

        // Assert
        Assert.Equal(4, service.Images.Count);
    }

    [Fact]
    public async Task CheckAnswer_WhenTwoSelectedItemsAreNotSame_ShouldMakeThemInvisible()
    {
        // Arrange
        ImageGameService service = new()
        {
            Images = { new Image { Value = "image1" }, new Image { Value = "image2" }, new Image { Value = "image1" }, new Image { Value = "image2" } }
        };

        // Act
        await service.AddSelectedItem(new Image { Value = "image1" });
        await service.AddSelectedItem(new Image { Value = "image2" });

        // Assert
        Assert.False(service.Images[0].IsVisible);
        Assert.False(service.Images[1].IsVisible);
    }
}
