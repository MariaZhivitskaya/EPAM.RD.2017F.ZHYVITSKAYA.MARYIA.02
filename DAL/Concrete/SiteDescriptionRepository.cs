using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;

namespace DAL.Concrete
{
    public class SiteDescriptionRepository : ISiteDescriptionRepository
    {
        private readonly DbContext _context;
        public SiteDescriptionRepository(DbContext uow)
        {
            _context = uow;
        }

        public IEnumerable<DalSiteDescription> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public DalSiteDescription GetById(int key)
        {
            var ormDesc = _context.Set<SiteDescription>().FirstOrDefault(desc => desc.Id == key);
            return new DalSiteDescription()
            {
                Id = ormDesc.Id,
                Text = ormDesc.Text
            };
        }

        public void Create(DalSiteDescription e)
        {
            throw new System.NotImplementedException();
        }
    }
}