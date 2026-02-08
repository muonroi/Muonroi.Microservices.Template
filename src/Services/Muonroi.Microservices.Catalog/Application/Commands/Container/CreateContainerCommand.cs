namespace Muonroi.Microservices.Catalog.Application.Commands.Container;

public sealed record CreateContainerCommand(string Code) : IRequest<MResponse<string>>;

