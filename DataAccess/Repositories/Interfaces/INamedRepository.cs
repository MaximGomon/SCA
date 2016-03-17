using SCA.Domain;

namespace SCA.DataAccess.Repositories.Interfaces
{
    public interface INamedRepository<TEntity> where TEntity : NamedEntity
    {
        TEntity GetByName(string name);
    }
}