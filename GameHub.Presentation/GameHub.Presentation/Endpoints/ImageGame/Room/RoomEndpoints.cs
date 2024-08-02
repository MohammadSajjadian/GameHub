using FluentValidation;
using GameHub.Application.ImageGame.Room.Commands.Requests;
using GameHub.Application.ImageGame.Room.Dto;
using GameHub.Application.ImageGame.Room.Repository;

namespace GameHub.Presentation.Endpoints.ImageGame.Room;

public static class RoomEndpoints
{
    public static async Task<IResult> CreateAsync(RoomDto roomDto, IValidator<RoomDto> validator, IRoomService service, CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(roomDto);

        if (!validationResult.IsValid)
            return Results.ValidationProblem(validationResult.ToDictionary());

        int result = await service.CreateAsync(roomDto, cancellationToken);
        return result == 0 ? Results.BadRequest("You already have a room. You should delete it to create a new one.") : result > 0 ? Results.Ok("Room created successfully")
            : Results.UnprocessableEntity("Failed to add room");
    }

    public static async Task<IResult> UpdateWinnerAsync(SetWinnerRequest request, IValidator<RoomDto> validator, IRoomService service, CancellationToken cancellationToken)
    {
        int result = await service.UpdateScoresAsync(request.Id, request.creatorScore, request.guestScore, cancellationToken);
        return result > 0 ? Results.Ok("Winner updated successfully") : Results.UnprocessableEntity("Failed to update winner");
    }

    public static async Task<IResult> DeleteAsync(int id, IRoomService service, CancellationToken cancellationToken)
    {
        int status = await service.DeleteAsync(id, cancellationToken);
        return status > 0 ? Results.BadRequest("Failed to delete room.") : Results.Ok();
    }

    public static async Task<List<RoomDto>?> GetAllAsync(IRoomService service, CancellationToken cancellationToken)
        => await service.GetAllAsync(cancellationToken);

    public static async Task<RoomDto?> GetAsync(int id, IRoomService service, CancellationToken cancellationToken)
        => await service.GetAsync(id, cancellationToken);
}
