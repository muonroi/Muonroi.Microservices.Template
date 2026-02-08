using Muonroi.BuildingBlock.Shared.License;
namespace Muonroi.Microservices.Data.Repository
{
    public class NotificationRepository(BaseTemplateDbContext dbContext, MAuthenticateInfoContext authContext, ILicenseGuard licenseGuard)
        : MRepository<NotificationEntity>(dbContext, authContext, licenseGuard), INotificationRepository
    {
    }
}






