using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class ClientSiteBusinessLogic : BaseBusinessLogic<IClientSiteRepository, ClientSite>, IClientSiteBusinessLogic
    {
        private readonly IClientSiteRepository _clientSiteRepository;
        public ClientSiteBusinessLogic(IClientSiteRepository repository) : base(repository)
        {
            _clientSiteRepository = repository;
        }
    }
}