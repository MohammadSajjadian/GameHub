using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ModularMonolithicArch.ImageGame.Application.Category.Dto;
using ModularMonolithicArch.ImageGame.Application.Image.Dto;
using ModularMonolithicArch.ImageGame.Application.Image.Mapper;
using ModularMonolithicArch.ImageGame.Application.Image.Repository;
using ModularMonolithicArch.ImageGame.Infrastructure.Context;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace ModularMonolithicArch.ImageGame.Infrastructure.Services;

public class ImageService(ImageGameContext db, IImageMapper mapper) : IImageService
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
        var imageEntity = db.Images.Find(imageId);
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

        var image = Image.Load(file.OpenReadStream());
        image.Mutate(x => x.Resize(resizeOptions));
        await image.SaveAsJpegAsync(saveLocation, cancellationToken);

        imageEntity.Name = fileName;
        await db.SaveChangesAsync(cancellationToken);

        return 1;
    }


    public async Task<List<ImageDto>?> GetRandomAsync(int categoryId, int boardSize, int seed, CancellationToken cancellationToken)
    {
        var images = await db.Images
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


    private async Task<Domain.Entities.Image?> GetAsync(int id, CancellationToken cancellationToken)
        => await db.Images.FindAsync(id, cancellationToken);


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

            return await db.Images
                .Where(i => i.Id == imageId)
                .ExecuteDeleteAsync(cancellationToken);
        }
        catch
        {
            return 0;
        }
    }


    public async Task<List<ImageDto>?> GetAllAsync(CancellationToken cancellationToken)
        => await db.Images.AsNoTracking().Select(i => new ImageDto
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
