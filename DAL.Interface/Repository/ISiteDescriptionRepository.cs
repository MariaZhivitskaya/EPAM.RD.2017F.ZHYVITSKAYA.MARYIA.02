using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface ISiteDescriptionRepository : IRepository<DalSiteDescription>
    {
        void Update(int id, string text);
    }
}