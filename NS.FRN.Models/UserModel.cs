using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static NS.FRN.Models.Common;
// using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace NS.FRN.Models
{
    public partial class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        // [Required(ErrorMessage ="FirstName is required")]
        //  public string LastName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [EmailAddress]
        //   [Display(Name = "Email")]
        // [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,6}", ErrorMessage = "Incorrect Email Format")]
        public string Email { get; set; }
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required]
        public string CityId { get; set; }
        public string StateId { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string CountryId { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]

        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please Enter Valid Mobile Number.")]
        public string MoboileNo { get; set; }
        public bool IsActive { get; set; }
        public bool? IsEmailVerified { get; set; }
        public Roles RoleId { get; set; }

        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int Pincode { get; set; }

    }
}