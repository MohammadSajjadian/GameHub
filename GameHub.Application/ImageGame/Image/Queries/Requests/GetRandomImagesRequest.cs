using GameHub.Application.ImageGame.Image.Dto;
using MediatR;

namespace GameHub.Application.ImageGame.Image.Queries.Requests;

public record GetRandomImagesRequest(int CategoryId, int BoardSize, int Seed) : IRequest<GetRandomImagesRequest.Response>
{
    public const string route = "/imageGame/image/random/categoryId/boardSize/seed";

    public record Response(List<ImageDto>? ImageDtos);
}
