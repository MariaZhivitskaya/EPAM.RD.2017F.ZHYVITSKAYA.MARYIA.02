using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface IAlbumRepository : IRepository<DalAlbum>
    {
        //void Update(int albumId);
        int GetAlbumId(string albumName);
    }
}