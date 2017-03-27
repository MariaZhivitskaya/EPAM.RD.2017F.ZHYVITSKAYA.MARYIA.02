using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IExtensionService
    {
        IEnumerable<ExtensionEntity> GetAllExtensionEntities();
        void CreateExtension(ExtensionEntity extension);
        int GetExtensionId(string extensionName);
    }
}