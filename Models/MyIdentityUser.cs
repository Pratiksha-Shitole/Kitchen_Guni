
using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kitchen_Guni.Models
{
    public class MyIdentityUser
        : IdentityUser<Guid>
    {


        [Display(Name = "EmailAddress")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
         public string EmailAddress { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        public int MobileNumber { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        public string Password { get; set; }


        [Display(Name = "Display Name")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        [MinLength(2, ErrorMessage = "{0} should have at least {1} characters.")]
        [StringLength(60, ErrorMessage = "{0} cannot have more than {1} characters.")]
        public string DisplayName { get; set; }


        [Display(Name = "Date of Birth")]
        [Required]
        [PersonalData]                                      // for GDPR Complaince
        [Column(TypeName = "smalldatetime")]
        public DateTime DateOfBirth { get; set; }


        [Display(Name = "Gender")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        public string Gender { get; set; }

        //[Display(Name = "Is Admin User?")]
        // [Required]
        // public bool IsAdminUser { get; set; }


        #region Navigational Properties to the Student Model (1:0 mapping)

        //public Student Student { get; set; }

        #endregion


        #region Navigational Properties to the Faculty Model (1:0 mapping)

        //public Faculty Faculty { get; set; }

        #endregion
    }
}