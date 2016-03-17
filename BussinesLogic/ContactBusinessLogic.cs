using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class ContactBusinessLogic : BaseBusinessLogic<ContactRepository, Contact>
    {
        private readonly ContactRepository _contactRepository;

        public ContactBusinessLogic(ContactRepository repository) : base(repository)
        {
            _contactRepository = repository;
        }
    }
}
