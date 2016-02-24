using System;
using System.ComponentModel.DataAnnotations;

namespace TrustMoi.ViewModels
{
    public class PersonDetailsVm
    {
        [Required]
        [Display(Name = @"First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = @"Last Name")]
        public string LastName { get; set; }

        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = @"Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Display(Name = @"Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = @"Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required]
        [Display(Name = @"Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = @"City")]
        public string City { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
    }

    public class ManagePersonVm
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Gender { get; set; }

        public string City { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string Address => $"{AddressLine1} {AddressLine2} {City}";

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool PhoneConfirmed { get; set; }

        public bool ReportedAbuse { get; set; }

        public bool Blocked { get; set; }
    }
}