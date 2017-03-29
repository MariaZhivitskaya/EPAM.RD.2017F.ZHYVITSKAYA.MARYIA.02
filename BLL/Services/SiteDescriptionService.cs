using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class SiteDescriptionService : ISiteDescriptionService
    {
        private readonly IUnitOfWork _uow;
        private readonly ISiteDescriptionRepository _descriptionRepository;

        public SiteDescriptionService(IUnitOfWork uow, ISiteDescriptionRepository repository)
        {
            _uow = uow;
            _descriptionRepository = repository;
        }


        public SiteDescriptionEntity GetDescriptionEntity(int id)
        {
            return _descriptionRepository.GetById(id).ToBllSiteDescription();
        }

        public void ChangeText(int id, string text)
        {
            _descriptionRepository.Update(id, text);
        }
    }
}