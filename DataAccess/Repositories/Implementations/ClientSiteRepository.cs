using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Implementations
{
    public class ClientSiteRepository: CrudRepository<ClientSite>, IClientSiteRepository
    {
        public ClientSite GetByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}