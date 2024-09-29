using MediatR;

namespace ModularMonolithicArch.User.Contract.Messages.Queries;

public record GetUserRequest(string UserName) : IRequest<ApplicationUserDto?>;
