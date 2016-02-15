using TrustMoi.Data.Interfaces;
using TrustMoi.Services.Base;
using TrustMoi.Services.Interfaces;
using TrustMoi.Services.Mappers;
using TrustMoi.ViewModels;

namespace TrustMoi.Services.Services
{
    public class PersonService : ServiceBase, IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonDetailMapper _personDetailMapper;

        public PersonService(IPersonRepository personRepository, IPersonDetailMapper personDetailMapper)
        {
            _personRepository = personRepository;
            _personDetailMapper = personDetailMapper;
        }

        public AdvisorPersonalDetailsVm GetPersonalDetailsByUserId(string userId)
        {
            return _personDetailMapper.Map(_personRepository.SingleOrDefault(p => p.UserId == userId));
        }
    }
}