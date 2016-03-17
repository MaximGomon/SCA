using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class ClientSiteBusinessLogic : BaseBusinessLogic<ClientSiteRepository, ClientSite>
    {
        private readonly ClientSiteRepository _clientSiteRepository;
        public ClientSiteBusinessLogic(ClientSiteRepository repository) : base(repository)
        {
            _clientSiteRepository = repository;
        }
    }
}