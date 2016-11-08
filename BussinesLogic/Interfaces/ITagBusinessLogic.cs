using SCA.Domain;

namespace SCA.BussinesLogic
{
    public interface ITagBusinessLogic : IBaseBusinessLogic<Tag>
    {
        Tag GetByName(string name);

        Tag GetByNameOrCreate(string name);
    }
}