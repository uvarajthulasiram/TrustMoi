using System.Linq;
using TrustMoi.Data;
using TrustMoi.Services.Base;
using TrustMoi.Services.Interfaces;
using TrustMoi.ViewModels;

namespace TrustMoi.Services.Mappers
{
    public class PersonDetailMapper : MapperBase, IPersonDetailMapper
    {
        public AdvisorPersonalDetailsVm Map(AspNetUser source)
        {
            var person = source.People.SingleOrDefault();
            var vm = new AdvisorPersonalDetailsVm
            {
                FirstName = source.FirstName,
                LastName = source.LastName,
                Phone = source.PhoneNumber,
                Email = source.Email
            };

            if (person == null) return vm;

            vm.Gender = person.Gender;
            vm.DateOfBirth = person.DateOfBirth;
            vm.AddressLine1 = person.AddressLine1;
            vm.AddressLine2 = person.AddressLine2;
            vm.City = person.City;

            return vm;
        }
    }

    public interface IPersonDetailMapper : IMapper<AspNetUser, AdvisorPersonalDetailsVm>
    {
    }
}