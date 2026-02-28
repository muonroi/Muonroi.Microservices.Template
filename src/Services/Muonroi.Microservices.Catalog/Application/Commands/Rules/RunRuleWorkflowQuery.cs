namespace Muonroi.Microservices.Catalog.Application.Commands.Rules;

public sealed record RunRuleWorkflowQuery(int Value, RuleExecutionMode? Mode = null)
    : IRequest<MResponse<RuleWorkflowSampleResult>>;

