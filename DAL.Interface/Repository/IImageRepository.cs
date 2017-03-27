using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface IImageRepository : IRepository<DalImage>
    {
        void Update(int imageId);
    }
}