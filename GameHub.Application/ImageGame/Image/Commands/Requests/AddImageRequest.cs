using GameHub.Application.ImageGame.Image.Dto;
using MediatR;

namespace GameHub.Application.ImageGame.Image.Commands.Requests;

public record AddImageRequest(ImageDto ImageDto) : IRequest<AddImageRequest.Response>
{
    public const string route = "/imageGame/image";

    public record Response(int StatusCode, int ImageId, string? Message = null);
}
