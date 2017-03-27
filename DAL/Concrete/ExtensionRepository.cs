using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;

namespace DAL.Concrete
{
    public class ExtensionRepository : IExtensionRepository
    {
        private readonly DbContext _context;
        public ExtensionRepository(DbContext uow)
        {
            _context = uow;
        }

        public IEnumerable<DalExtension> GetAll()
        {
            //var extCount = _context.Set<Extension>().Count();
            //if (extCount == 0)
            //    return null;

            return _context.Set<Extension>().Select(ext => new DalExtension()
            {
                Id = ext.Id,
                Name = ext.Name
            });
        }

        public DalExtension GetById(int key)
        {
            throw new System.NotImplementedException();
        }

        public void Create(DalExtension e)
        {
            var extension = new Extension()
            {
                Name = e.Name,
            };
            _context.Set<Extension>().Add(extension);
        }

        public int GetExtensionId(string extensionName)
        {
            return _context.Set<Extension>().FirstOrDefault(ext => ext.Name == extensionName).Id;
        }
    }
}