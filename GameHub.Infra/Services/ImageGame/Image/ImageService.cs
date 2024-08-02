using GameHub.Application.ImageGame.Category.Dto;
using GameHub.Application.ImageGame.Image.Dto;
using GameHub.Application.ImageGame.Image.Mapper;
using GameHub.Application.ImageGame.Image.Repository;
using GameHub.Domain.Entities.ImageGame;
using GameHub.Infra.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace GameHub.Infra.Services.ImageGame.Image;

public class ImageService(GameContext db, IImageMapper mapper) : IImageService
{
    public async Task<int> CreateAsync(ImageDto imageDto, CancellationToken cancellationToken)
    {
        var image = mapper.Map(imageDto);

        db.Add(image);
        await db.SaveChangesAsync(cancellationToken);

        return image.Id;
    }


    public async Task<int> UploadImageAsync(int imageId, IFormFile file, CancellationToken cancellationToken)
    {
        var imageEntity = db.ImageGameImages.Find(imageId);
        if (imageEntity is null)
            return -1;

        if (file.Length is 0)
            return 0;

        var fileName = $"{Guid.NewGuid()}.jpg";
        var saveLocation = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

        var resizeOptions = new ResizeOptions()
        {
            Mode = ResizeMode.Stretch,
            Size = new Size(640, 426),
        };

        var image = SixLabors.ImageSharp.Image.Load(file.OpenReadStream());
        image.Mutate(x => x.Resize(resizeOptions));
        await image.SaveAsJpegAsync(saveLocation, cancellationToken);

        imageEntity.Name = fileName;
        await db.SaveChangesAsync(cancellationToken);

        return 1;
    }


    public async Task<List<ImageDto>?> GetRandomAsync(int categoryId, int boardSize, int seed, CancellationToken cancellationToken)
    {
        var images = await db.ImageGameImages
            .AsNoTracking()
            .Where(i => i.CategoryId == categoryId)
            .Select(i => new ImageDto
            {
                Name = i.Name!,
            }).ToListAsync(cancellationToken);

        var random = new Random(seed);
        return images
            .OrderBy(i => random.Next())
            .Take(boardSize)
            .ToList();
    }


    private async Task<Domain.Entities.ImageGame.Image?> GetAsync(int id, CancellationToken cancellationToken)
        => await db.ImageGameImages.FindAsync(id, cancellationToken);


    private void DeleteFromFile(string imageName)
        => File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", imageName));


    public async Task<int> DeleteAsync(int imageId, CancellationToken cancellationToken)
    {
        try
        {
            var image = await GetAsync(imageId, cancellationToken);
            if (image is null)
                return 0;

            DeleteFromFile(image.Name!);

            return await db.ImageGameImages
                .Where(i => i.Id == imageId)
                .ExecuteDeleteAsync(cancellationToken);
        }
        catch
        {
            return 0;
        }
    }


    public async Task<List<ImageDto>?> GetAllAsync(CancellationToken cancellationToken)
        => await db.ImageGameImages.AsNoTracking().Select(i => new ImageDto
        {
            Id = i.Id,
            Name = i.Name!,
            CategoryDto = new CategoryDto()
            {
                Name = i.Category.Name,
            }
        })
        .ToListAsync(cancellationToken);
}
