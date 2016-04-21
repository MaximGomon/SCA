using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class ClientSitePagesBusinessLogic : BaseBusinessLogic<ClientSitePageRepository, ClientSitePage>
    {
        private readonly ClientSitePageRepository _clientSitePageRepository;
        public ClientSitePagesBusinessLogic(ClientSitePageRepository repository) : base(repository)
        {
            _clientSitePageRepository = repository;
        }
    }
}