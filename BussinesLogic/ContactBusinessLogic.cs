using System;
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

        public Contact GetByName(string name)
        {
            return _contactRepository.GetByName(name);
        }

        public Contact GetByLogin(string login)
        {
            return _contactRepository.GetByLogin(login);
        }
    }
}
