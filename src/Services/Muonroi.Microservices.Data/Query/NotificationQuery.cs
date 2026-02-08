using Muonroi.BuildingBlock.Shared.License;
namespace Muonroi.Microservices.Data.Query
{
    public class NotificationQuery(BaseTemplateDbContext dbContext, MAuthenticateInfoContext authContext, ILicenseGuard licenseGuard)
        : MQuery<NotificationEntity>(dbContext, authContext, licenseGuard), INotificationQuery
    {
    }
}






