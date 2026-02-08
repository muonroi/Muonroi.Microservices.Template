namespace Muonroi.Microservices.Catalog.Application.Commands.Rules;

public sealed record EvaluateNumberQuery(int Value) : IRequest<MResponse<FactBag>>;

