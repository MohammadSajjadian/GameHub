using MediatR;

namespace ModularMonolithicArch.User.Contract.Messages.Queries;

public record GetCurrentUserRequest() : IRequest<ApplicationUserDto>;
