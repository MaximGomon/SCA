using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class TagBusinessLogic : BaseBusinessLogic<TagRepository, Tag>
    {
        public readonly TagRepository _tagRepository;
        public TagBusinessLogic(TagRepository repository) : base(repository)
        {
            _tagRepository = repository;
        }

        public Tag GetByName(string name)
        {
            return Repository.GetByName(name);
        }

        public Tag GetByNameOrCreate(string name)
        {
            var result = Repository.GetByName(name);
            if (result == null)
            {
                result = new Tag
                {
                    Name = name,
                    IsDeleted = false
                };
                Repository.Add(result);
            }
            return result;
        }
    }
}