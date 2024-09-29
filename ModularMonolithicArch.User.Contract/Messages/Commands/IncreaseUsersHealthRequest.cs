using MediatR;

namespace ModularMonolithicArch.User.Contract.Messages.Commands;

public record IncreaseUsersHealthRequest() : IRequest<int>;
