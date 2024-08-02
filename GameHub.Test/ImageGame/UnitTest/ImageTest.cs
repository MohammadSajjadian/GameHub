using GameHub.Presentation.Client.Services.ImageGame;

namespace GameHub.Test.ImageGame.UnitTest;

public class ImageTest
{
    [Fact]
    public void MarkAsVisible_WhenClickOnImage_ShouldMakeItVisible()
    {
        // Arrange
        Image image = new();

        // Act
        image.MarkAsVisible();

        // Assert
        Assert.True(image.IsVisible);
    }
}
