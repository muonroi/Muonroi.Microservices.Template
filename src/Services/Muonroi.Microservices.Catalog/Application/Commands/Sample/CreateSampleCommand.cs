

namespace Muonroi.Microservices.Catalog.Application.Commands.Sample
{
    public class CreateSampleCommand : IRequest<MResponse<SampleDto>>
    {
        public string Name { get; set; } = string.Empty;
    }
}

