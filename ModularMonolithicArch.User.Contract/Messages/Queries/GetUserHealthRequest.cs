using MediatR;

namespace ModularMonolithicArch.User.Contract.Messages.Queries;

public record GetUserHealthRequest(string UserName) : IRequest<ApplicationUserDto?>;
