using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class TagBusinessLogic : BaseBusinessLogic<ITagRepository, Tag>, ITagBusinessLogic
    {
        private readonly ITagRepository _tagRepository;
        public TagBusinessLogic(ITagRepository repository) : base(repository)
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