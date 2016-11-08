using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class ClientSitePagesBusinessLogic : BaseBusinessLogic<IClientSitePageRepository, ClientSitePage>, IClientSitePagesBusinessLogic
    {
        private readonly IClientSitePageRepository _clientSitePageRepository;
        public ClientSitePagesBusinessLogic(IClientSitePageRepository repository) : base(repository)
        {
            _clientSitePageRepository = repository;
        }
    }
}