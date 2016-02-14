using System.ComponentModel;
using TrustMoi.Common.Enums;

namespace TrustMoi.ViewModels
{
    public class AdvisorPersonalDetailsVm
    {
        [DisplayName(@"First Name")]
        public string FirstName { get; set; }

        [DisplayName(@"Last Name")]
        public string LastName { get; set; }

        [DisplayName(@"Date of Birth")]
        public string DateOfBirth { get; set; }

        [DisplayName(@"Address Line 1")]
        public string AddressLine1 { get; set; }

        [DisplayName(@"Address Line 2")]
        public string AddressLine2 { get; set; }

        public GenderEnum Gender { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
    }
}