using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface IExtensionRepository : IRepository<DalExtension>
    {
        int GetExtensionId(string extensionName);
    }
}