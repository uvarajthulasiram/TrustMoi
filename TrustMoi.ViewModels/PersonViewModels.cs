using System;
using System.Collections.Generic;
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
        public DateTime DateOfBirth { get; set; }

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
    }

    public class PersonQuestionAnswerVm
    {
        public string Question { get; set; }
        public IEnumerable<string> Answers { get; set; }
    }
}