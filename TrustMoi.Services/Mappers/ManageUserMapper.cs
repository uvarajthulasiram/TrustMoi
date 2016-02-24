using TrustMoi.Data;
using TrustMoi.Services.Base;
using TrustMoi.Services.Interfaces;
using TrustMoi.ViewModels;

namespace TrustMoi.Services.Mappers
{
    public class ManageUserMapper : MapperBase, IManageUserMapper
    {
        public ManagePersonVm Map(AspNetUser source)
        {
            var person = source.UserPerson;
            var vm = new ManagePersonVm
            {
                FirstName = source.FirstName,
                LastName = source.LastName,
                Phone = source.PhoneNumber,
                Email = source.Email,
                EmailConfirmed = source.EmailConfirmed,
                PhoneConfirmed = source.PhoneNumberConfirmed
            };

            if (person == null) return vm;

            vm.Gender = person.Gender;
            vm.DateOfBirth = person.DateOfBirth;
            vm.AddressLine1 = person.AddressLine1;
            vm.AddressLine2 = person.AddressLine2;
            vm.City = person.City;
            vm.Blocked = person.IsBlocked;
            vm.ReportedAbuse = false; //ToDo: If user post abusive content reported by other users, then mark the user as abusive user.

            return vm;
        }
    }

    public interface IManageUserMapper : IMapper<AspNetUser, ManagePersonVm>
    {
    }
}