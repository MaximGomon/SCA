using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Implementations
{
    public class SocialNetworkRepository: CrudRepository<SocialNetworkEvent>, ISocialNetworkRepository
    {
         public SocialNetworkRepository (IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        { }
    }
}