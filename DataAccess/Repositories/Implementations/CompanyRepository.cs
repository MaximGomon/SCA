using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Implementations
{
    public class CompanyRepository : CrudRepository<Company>, ICompanyRepository 
    {
        public Company GetByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}