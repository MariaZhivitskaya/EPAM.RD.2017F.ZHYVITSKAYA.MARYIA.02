using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class ExtensionService : IExtensionService
    {
        private readonly IUnitOfWork _uow;
        private readonly IExtensionRepository _extensionRepository;

        public ExtensionService(IUnitOfWork uow, IExtensionRepository repository)
        {
            _uow = uow;
            _extensionRepository = repository;
        }

        public IEnumerable<ExtensionEntity> GetAllExtensionEntities()
        {
            return _extensionRepository.GetAll().Select(ext => ext.ToBllExtension());
        }

        public void CreateExtension(ExtensionEntity extension)
        {
            _extensionRepository.Create(extension.ToDalExtension());
            _uow.Commit();
        }

        public int GetExtensionId(string extensionName)
        {
            return _extensionRepository.GetExtensionId(extensionName);
        }
    }
}