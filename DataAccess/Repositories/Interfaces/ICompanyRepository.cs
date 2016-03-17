using SCA.Domain;

namespace SCA.DataAccess.Repositories.Interfaces
{
    public interface ICompanyRepository : ICRUDRepository<Company>, INamedRepository<Company>
    {
    }
}
