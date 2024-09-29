using MediatR;
using ModularMonolithicArch.ImageGame.Application.Image.Dto;

namespace ModularMonolithicArch.ImageGame.Application.Image.Commands.Requests;

public record AddImageRequest(ImageDto ImageDto) : IRequest<AddImageRequest.Response>
{
    public const string route = "/imageGame/image";

    public record Response(int StatusCode, int ImageId, string? Message = null);
}
