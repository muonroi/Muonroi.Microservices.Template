using Muonroi.BuildingBlock.Shared.License;
namespace Muonroi.Microservices.Data.Repository
{
    public class SampleRepository(BaseTemplateDbContext dbContext, MAuthenticateInfoContext authContext, ILicenseGuard licenseGuard)
        : MRepository<SampleEntity>(dbContext, authContext, licenseGuard), ISampleRepository
    {
    }
}






