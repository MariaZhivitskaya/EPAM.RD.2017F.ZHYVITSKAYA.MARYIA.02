using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface ISiteDescriptionService
    {
        SiteDescriptionEntity GetDescriptionEntity(int id);
    }
}