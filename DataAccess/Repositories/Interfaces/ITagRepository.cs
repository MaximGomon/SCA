using SCA.Domain;

namespace SCA.DataAccess.Repositories.Interfaces
{
    public interface ITagRepository : ICRUDRepository<Tag>
    {
        Tag GetByName(string name);
    }
}