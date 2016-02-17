﻿using System.Collections.Generic;
using System.Linq;
using TrustMoi.Data;
using TrustMoi.Data.Interfaces;
using TrustMoi.Services.Base;
using TrustMoi.Services.Interfaces;
using TrustMoi.Services.Mappers;
using TrustMoi.ViewModels;

namespace TrustMoi.Services.Services
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPersonDetailMapper _personDetailMapper;

        public UserService(IUserRepository userRepository, IPersonRepository personRepository, IPersonDetailMapper personDetailMapper)
        {
            _userRepository = userRepository;
            _personRepository = personRepository;
            _personDetailMapper = personDetailMapper;
        }

        public AdvisorPersonalDetailsVm GetPersonalDetailsByUserId(string userId)
        {
            return _personDetailMapper.Map(_userRepository.Single(p => p.Id == userId));
        }

        public void SavePersonalDetails(AdvisorPersonalDetailsVm model, string userId)
        {
            var user = _userRepository.Single(p => p.Id == userId);

            if (user.People.Any()) GetUpdatedPersonFromVm(model, user);
            else CreateNewPersonFromVm(model, user);

            _userRepository.Modify(user);
            _userRepository.SaveChanges();
        }

        private void CreateNewPersonFromVm(AdvisorPersonalDetailsVm model, AspNetUser user)
        {
            var person = _personRepository.NewObject();

            SetUserProperties(model, user);
            SetPersonProperties(model, person);

            user.People.Add(person);
        }

        private static void GetUpdatedPersonFromVm(AdvisorPersonalDetailsVm model, AspNetUser user)
        {
            var person = user.People.Single();

            SetUserProperties(model, user);
            SetPersonProperties(model, person);
        }

        private static void SetPersonProperties(AdvisorPersonalDetailsVm model, Person person)
        {
            person.DateOfBirth = model.DateOfBirth;
            person.AddressLine1 = model.AddressLine1;
            person.AddressLine2 = model.AddressLine2;
            person.Gender = model.Gender;
            person.City = model.City;
        }

        private static void SetUserProperties(AdvisorPersonalDetailsVm model, AspNetUser user)
        {
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
        }
    }
}