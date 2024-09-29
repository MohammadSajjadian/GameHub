using MediatR;

namespace ModularMonolithicArch.User.Contract.Messages.Commands;

public record DecreaseUserHealthRequest(string UserName) : IRequest<bool>;
