using TrustMoi.Data;
using TrustMoi.Services.Base;
using TrustMoi.Services.Interfaces;
using TrustMoi.ViewModels;

namespace TrustMoi.Services.Mappers
{
    public class PersonDetailMapper : MapperBase, IPersonDetailMapper
    {
        public AdvisorPersonalDetailsVm Map(Person source)
        {
            var aspNetUser = source.AspNetUser;

            return new AdvisorPersonalDetailsVm
            {
                FirstName = source.FirstName,
                LastName = source.LastName,
                Gender = source.Gender,
                DateOfBirth = source.DateOfBirth,
                AddressLine1 = source.AddressLine1,
                AddressLine2 = source.AddressLine2,
                City = source.City,
                Phone = aspNetUser == null ? string.Empty : aspNetUser.PhoneNumber,
                Email = aspNetUser == null ? string.Empty : aspNetUser.Email
            };
        }
    }

    public interface IPersonDetailMapper : IMapper<Person, AdvisorPersonalDetailsVm>
    {
    }
}