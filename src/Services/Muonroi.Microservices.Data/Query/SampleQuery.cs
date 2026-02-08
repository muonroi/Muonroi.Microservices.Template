using Muonroi.BuildingBlock.Shared.License;




namespace Muonroi.Microservices.Data.Query
{
    public class SampleQuery(BaseTemplateDbContext dbContext, MAuthenticateInfoContext authContext, ILicenseGuard licenseGuard)
    : MQuery<SampleEntity>(dbContext, authContext, licenseGuard), ISampleQuery
    {
    }
}






