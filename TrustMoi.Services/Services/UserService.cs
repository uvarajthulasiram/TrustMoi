using System.Collections.Generic;
using System.Linq;
using TrustMoi.Data;
using TrustMoi.Data.Interfaces;
using TrustMoi.Services.Base;
using TrustMoi.Services.Interfaces;
using TrustMoi.Services.Mappers;
using TrustMoi.ViewModels;
using PersonQuestionAnswerVm = TrustMoi.ViewModels.PersonQuestionAnswerVm;

namespace TrustMoi.Services.Services
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuestionAnswerMapper _questionAnswerMapper;
        private readonly IPersonDetailMapper _personDetailMapper;

        public UserService(IUserRepository userRepository, IPersonRepository personRepository, IPersonDetailMapper personDetailMapper, IQuestionRepository questionRepository, IQuestionAnswerMapper questionAnswerMapper)
        {
            _userRepository = userRepository;
            _personRepository = personRepository;
            _personDetailMapper = personDetailMapper;
            _questionRepository = questionRepository;
            _questionAnswerMapper = questionAnswerMapper;
        }

        public PersonDetailsVm GetPersonalDetailsByUserId(string userId)
        {
            return _personDetailMapper.Map(_userRepository.Single(p => p.Id == userId));
        }

        public IEnumerable<PersonQuestionAnswerVm> GetPersonQuestionAnswers()
        {
            return _questionRepository.GetAll().Select(p => _questionAnswerMapper.Map(p));
        }

        public void SavePersonalDetails(PersonDetailsVm model, string userId)
        {
            var user = _userRepository.Single(p => p.Id == userId);

            if (user.Person != null) GetUpdatedPersonFromVm(model, user);
            else CreateNewPersonFromVm(model, user);

            _userRepository.Modify(user);
            _userRepository.SaveChanges();
        }

        private void CreateNewPersonFromVm(PersonDetailsVm model, AspNetUser user)
        {
            var person = _personRepository.NewObject();

            SetUserProperties(model, user);
            SetPersonProperties(model, person);

            user.Person = person;
        }

        private static void GetUpdatedPersonFromVm(PersonDetailsVm model, AspNetUser user)
        {
            var person = user.Person;

            SetUserProperties(model, user);
            SetPersonProperties(model, person);
        }

        private static void SetPersonProperties(PersonDetailsVm model, Person person)
        {
            person.DateOfBirth = model.DateOfBirth;
            person.AddressLine1 = model.AddressLine1;
            person.AddressLine2 = model.AddressLine2;
            person.Gender = model.Gender;
            person.City = model.City;
        }

        private static void SetUserProperties(PersonDetailsVm model, AspNetUser user)
        {
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.Phone;
        }
    }
}