using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Implementations
{
    public class LeadRepository : CrudRepository<Lead>, ILeadRepository
    {
         
    }
}