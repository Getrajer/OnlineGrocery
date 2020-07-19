using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.ViewModels
{
    public class EditUserInfoViewModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [Display(Name = "Street name")]
        public string StreetName { get; set; }
        [Required]
        [Display(Name = "Street number")]
        public string StreetNumber { get; set; }
        [Required]
        public string PostCode { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
