using MediatR;
using Microsoft.AspNetCore.Components.Forms;

namespace ModularMonolithicArch.ImageGame.Application.Image.Commands.Requests;

public record UploadImageRequest(int ImageId, IBrowserFile File) : IRequest<UploadImageRequest.Response>
{
    public const string route = "/imageGame/image/upload/imageId";

    public record Response(int StatusCode, string? Message = null);
}
