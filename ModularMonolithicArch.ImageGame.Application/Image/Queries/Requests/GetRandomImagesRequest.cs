using MediatR;
using ModularMonolithicArch.ImageGame.Application.Image.Dto;

namespace ModularMonolithicArch.ImageGame.Application.Image.Queries.Requests;

public record GetRandomImagesRequest(int CategoryId, int BoardSize, int Seed) : IRequest<GetRandomImagesRequest.Response>
{
    public const string route = "/imageGame/image/random/categoryId/boardSize/seed";

    public record Response(List<ImageDto>? ImageDtos);
}
