using GameHub.Application.ImageGame.Image.Dto;
using Microsoft.AspNetCore.Http;

namespace GameHub.Application.ImageGame.Image.Repository;

public interface IImageService
{
    Task<int> CreateAsync(ImageDto imageDto, CancellationToken cancellationToken);
    Task<int> UploadImageAsync(int imageId, IFormFile file, CancellationToken cancellationToken);
    Task<int> DeleteAsync(int imageId, CancellationToken cancellationToken);
    Task<List<ImageDto>?> GetRandomAsync(int categoryId, int boardSize, int seed, CancellationToken cancellationToken);
    Task<List<ImageDto>?> GetAllAsync(CancellationToken cancellationToken);
}
